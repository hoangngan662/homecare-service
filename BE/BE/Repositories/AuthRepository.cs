using AutoMapper;
using BE.Data;
using BE.Dtos;
using BE.Models;
using BE.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BE.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private const string SecretKey = "pL3@w9Kx7$hD2b8QeTz0&yR1uFq#5jJd\r\n";

        public AuthRepository(AppDbContext context, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginRes> Login(LoginReq req)
        {
            var user = await _userManager.FindByEmailAsync(req.Email);
            if (user == null)
            {
                return null; // User not found
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, req.Password, false);
            if (!result.Succeeded)
            {
                return null; // Password incorrect
            }

            var token = await GenerateJwtToken(user); // Generate JWT token with roles

            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();

            return new LoginRes
            {
                Token = token,
                Username = user.Email,
            };
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id),
                new Claim("fullname", user.Fullname),
            };

            // Fetch user roles
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role)); // Add each role as a claim
            }

            // Ensure the key is at least 16 bytes (128 bits)
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<User> Register(UserCreateDto request)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = _mapper.Map<User>(request);
                    user.UserName = request.Email;
                    user.Email = request.Email;

                    var result = await _userManager.CreateAsync(user, request.Password);
                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException("Failed to create user. Errors: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                    }

                    if (request.Roles != null && request.Roles.Length > 0)
                    {
                        var roleResult = await _userManager.AddToRolesAsync(user, request.Roles);
                        if (!roleResult.Succeeded)
                        {
                            throw new InvalidOperationException("Failed to assign roles. Errors: " + string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                        }
                    }

                    await transaction.CommitAsync();
                    return user;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<bool> CheckUsedEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            var userMail = await _context.Users.AnyAsync(x => x.Email == email);
            return userMail;
        }
    }
}
