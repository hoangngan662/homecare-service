using BE.Dtos;
using BE.Models;
using BE.Repositories.Interfaces;
using CsvHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BE.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<UserDto> GetUserByIdAsync(string userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<PaginatedResult<UserDto>> GetUserByRoleIdAsync(string roleId, int pageNumber, int pageSize)
        {
            return await _userRepository.GetUserByRoleIdAsync(roleId, pageNumber, pageSize);
        }

        public async Task<UserDto> AddUserAsync(UserCreateDto userDto)
        {
            return await _userRepository.AddUserAsync(userDto);
        }

        public async Task UpdateUserAsync(string id, UserCreateDto userDto)
        {
            await _userRepository.UpdateUserAsync(id, userDto);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task ChangePasswordAsync(ChangePasswordDto model)
        {
            await _userRepository.ChangePasswordAsync(model);
        }

        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            return await _userRepository.GetAllRolesAsync();
        }

        public async Task AddRoleAsync(RoleDto roleDto)
        {
            await _userRepository.AddRoleAsync(roleDto);
        }

        public async Task UploadCsv(IFormFile file)
        {
            //await _userRepository.UploadCsv(file);
            if (file == null || file.Length == 0)
                throw new ArgumentNullException(nameof(file));

            var users = new List<UserCreateDto>();

            using (var stream = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(stream, CultureInfo.InvariantCulture))
            {
                users = csv.GetRecords<UserCreateDto>().ToList();
            }
            foreach (var userDto in users)
            {
                userDto.Roles = new[] { "Staff" };
                //userDto.Roles = new[] { "Patient" };
                //userDto.Specialization = null;
                //userDto.StartDate = null;
                await _userRepository.AddUserAsync(userDto);
            }
        }

        public async Task<AddressDto> GetAddressBySubIdAsync(int id)
        {
            return await _userRepository.GetAddressBySubIdAsync(id);
        }

        public async Task<IEnumerable<UserDto>> GetUsersByShiftAsync(int shiftId, DateTime shiftDate)
        {
            return await _userRepository.GetUsersByShiftAsync(shiftId, shiftDate);
        }
    }
}
