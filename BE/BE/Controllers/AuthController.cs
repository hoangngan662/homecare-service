using BE.Dtos;
using BE.Models;
using BE.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.Cookies;
using Google.Apis.Auth;
using System.Text;

namespace BE.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private const string SecretKey = "pL3@w9Kx7$hD2b8QeTz0&yR1uFq#5jJd\r\n";
        public AuthController(AuthService authService, UserManager<User> userManager, IConfiguration configuration)
        {
            _authService = authService;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginReq req)
        {
            try
            {
                var res = await _authService.Login(req);
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest(new { code = 1, message = "Đăng nhập thất bại, hãy kiểm tra lại." });
                }
            }
            catch (Exception ex) {
                return BadRequest(new { code = 1, message = "Đăng nhập thất bại, hãy kiểm tra lại." });
            }            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreateDto request)
        {
            try
            {
                await _authService.Register(request);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(new { code = 1, message = "Đăng ký thất bại, hãy kiểm tra lại." });
            }
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest request)
        {
            try
            {
                // Xác thực token từ Google
                var payload = await GoogleJsonWebSignature.ValidateAsync(request.TokenId, new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new[] { _configuration["Google:ClientId"] } // Client ID của bạn
                });

                // Tìm người dùng theo email
                var user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    // Người dùng chưa tồn tại, trả về thông tin người dùng từ payload
                    var newUser = new User
                    {
                        UserName = payload.Email,
                        Email = payload.Email,
                        Fullname = payload.Name
                    };
                    return Ok(new { User = newUser, IsNewUser = true });
                }
                // Nếu đã có người dùng

                var token = await GenerateJwtToken(user);

                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();

                return Ok(new LoginRes
                {
                    Token = token,
                    Username = user.Email,
                });
            }
            catch (InvalidJwtException ex)
            {
                return Unauthorized(new { Message = "Invalid token", Error = ex.Message });
            }
        }

        [HttpPost("google-login-info")]
        public async Task<IActionResult> GoogleLoginInfo(UserCreateDto request)
        {
            try
            {
                var user = await _authService.Register(request);
                if (user != null)
                {
                    var token = await GenerateJwtToken(user);

                    var roles = await _userManager.GetRolesAsync(user);
                    var role = roles.FirstOrDefault();

                    return Ok(new LoginRes
                    {
                        Token = token,
                        Username = user.Email,
                    });
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Cập nhật thông tin thất bại, hãy kiểm tra lại." });
            }
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
    }
}
