using AutoMapper;
using BE.Data;
using BE.Dtos;
using BE.Models;
using BE.Repositories.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BE.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository
        (AppDbContext context, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            var userDtos = new List<UserDto>();

            foreach (var user in users)
            {
                var userDto = _mapper.Map<UserDto>(user);
                var roles = await _userManager.GetRolesAsync(user);

                userDto.Roles = roles.ToList();

                userDtos.Add(userDto);
            }

            return userDtos;
        }
        public async Task<UserDto> GetUserByIdAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);

            var userDto = _mapper.Map<UserDto>(user);

            var roles = await _userManager.GetRolesAsync(user);
            userDto.Roles = roles.ToList();

            return userDto;
        }

        public async Task<PaginatedResult<UserDto>> GetUserByRoleIdAsync(string roleId, int pageNumber, int pageSize)
        {
            var usersInRole = new List<string>();
            if (roleId != "3")
            {
                usersInRole = await _context.UserRoles
                .Where(ur => ur.RoleId != "3")
                .Select(ur => ur.UserId)
                .ToListAsync();
            }
            else
            {
                usersInRole = await _context.UserRoles
                .Where(ur => ur.RoleId == roleId)
                .Select(ur => ur.UserId)
                .ToListAsync();
            }        

            var totalCount = await _context.Users
                .Where(u => usersInRole.Contains(u.Id) && !u.IsDeleted)
                .CountAsync();

            var users = await _context.Users
                .Where(u => usersInRole.Contains(u.Id) && !u.IsDeleted)
                .OrderByDescending(u => u.CreateAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var userDtos = new List<UserDto>();
            foreach (var user in users)
            {
                var userDto = _mapper.Map<UserDto>(user);
                var roles = await _userManager.GetRolesAsync(user);
                userDto.Roles = roles.ToList();
                userDtos.Add(userDto);
            }

            return new PaginatedResult<UserDto>
            {
                Items = userDtos,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task<UserDto> AddUserAsync(UserCreateDto userDto)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = _mapper.Map<User>(userDto);
                    user.UserName = userDto.Email;
                    user.Email = userDto.Email;

                    var result = await _userManager.CreateAsync(user, userDto.Password);
                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException("Failed to create user. Errors: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                    }

                    if (userDto.Roles != null && userDto.Roles.Length > 0)
                    {
                        var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
                        if (!roleResult.Succeeded)
                        {
                            throw new InvalidOperationException("Failed to assign roles. Errors: " + string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                        }
                    }

                    await transaction.CommitAsync();
                    return _mapper.Map<UserDto>(user);
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task UpdateUserAsync(string id, UserCreateDto userDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.Fullname = userDto.Fullname;
                user.Address = userDto.Address;
                user.DoB = userDto.DoB;
                user.PhoneNumber = userDto.PhoneNumber;
                user.Specialization = userDto.Specialization;
                user.StartDate = userDto.StartDate;
                _context.Users.Update(user);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                _context.Users.Update(user);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            var roles = await _context.Roles.ToListAsync();

            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public async Task AddRoleAsync(RoleDto roleDto)
        {
            var role = _mapper.Map<IdentityRole>(roleDto);
            var existingRole = await _roleManager.FindByNameAsync(role.Name);
            if (existingRole != null)
            {
                throw new InvalidOperationException("Role already exists.");
            }

            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Failed to create role. Errors: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }

        public async Task ChangePasswordAsync(ChangePasswordDto model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Failed to change password.");
            }
        }

        public async Task UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentNullException(nameof(file));

            var users = new List<UserCreateDto>();

            using (var stream = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(stream, CultureInfo.InvariantCulture))
            {
                users = csv.GetRecords<UserCreateDto>().ToList();
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (var userDto in users)
                    {
                        var user = _mapper.Map<User>(userDto);
                        user.UserName = userDto.Email;
                        user.Email = userDto.Email;

                        var result = await _userManager.CreateAsync(user, userDto.Password);
                        if (!result.Succeeded)
                        {
                            string errorMessages = string.Join(", ", result.Errors.Select(e => e.Description));
                            throw new Exception($"User creation failed: {errorMessages}");
                        }

                        if (userDto.Roles != null && userDto.Roles.Length > 0)
                        {
                            var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
                            if (!roleResult.Succeeded)
                            {
                                string roleErrorMessages = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                                throw new InvalidOperationException($"Failed to assign roles to user. Errors: {roleErrorMessages}");
                            }
                        }
                    }

                    await transaction.CommitAsync(); // Commit transaction if everything is successful
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(); // Rollback transaction on error
                                                       // Log or handle the exception as necessary
                    throw;
                }
            }
        }

        public async Task<AddressDto> GetAddressBySubIdAsync(int id)
        {
            var subs = await _context.Subscriptions.Where(s => s.Id == id).FirstOrDefaultAsync();
            if(subs != null)
            {
                var user = await _context.Users.Where(u => u.Id == subs.PatientId).FirstOrDefaultAsync();
                if (user != null) {
                    return new AddressDto
                    {
                        UserId = user.Id,
                        Address = user.Address,
                        Phone = user.PhoneNumber
                    };
                }
            }
            return new AddressDto { };
        }

        public async Task<IEnumerable<UserDto>> GetUsersByShiftAsync(int shiftId, DateTime shiftDate)
        {
            // Lấy danh sách ID nhân viên không có vai trò là "3"
            var usersInRole = await _context.UserRoles
                .Where(ur => ur.RoleId != "3")
                .Select(ur => ur.UserId)
                .ToListAsync();

            // Lấy danh sách lịch hẹn trong ngày và ca đã chỉ định
            var appointmentsInShift = await _context.Appointments
                .Where(a => a.AppointmentDate.Date == shiftDate.Date && a.ShiftId == shiftId 
                            && a.Status != AppointmentStatus.Completed && a.Status != AppointmentStatus.Cancelled)
                .Select(a => a.StaffId) // Lấy ID nhân viên từ lịch hẹn
                .ToListAsync();

            // Lấy danh sách nhân viên chưa có lịch hẹn trong ngày và ca đã chỉ định
            var users = await _context.Users
                .Where(u => usersInRole.Contains(u.Id) && !u.IsDeleted && !appointmentsInShift.Contains(u.Id))
                .ToListAsync();

            var userDtos = new List<UserDto>();
            foreach (var user in users)
            {
                var userDto = _mapper.Map<UserDto>(user);
                var roles = await _userManager.GetRolesAsync(user);
                userDto.Roles = roles.ToList();
                userDtos.Add(userDto);
            }
            return userDtos;
        }
    }
}
