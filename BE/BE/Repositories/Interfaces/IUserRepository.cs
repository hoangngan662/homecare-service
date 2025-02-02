using BE.Dtos;
using Microsoft.AspNetCore.Identity;

namespace BE.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(string id);
        Task<PaginatedResult<UserDto>> GetUserByRoleIdAsync(string id, int pageNumber, int pageSize);
        Task<UserDto> AddUserAsync(UserCreateDto userDto);
        Task UpdateUserAsync(string id, UserCreateDto userDto);
        Task DeleteUserAsync(string id);
        Task ChangePasswordAsync(ChangePasswordDto model);
        Task<IEnumerable<RoleDto>> GetAllRolesAsync();
        Task AddRoleAsync(RoleDto roleDto);
        Task UploadCsv(IFormFile file);
        Task<AddressDto> GetAddressBySubIdAsync(int id);
        Task<IEnumerable<UserDto>> GetUsersByShiftAsync(int shiftId, DateTime shiftDate);
    }
}
