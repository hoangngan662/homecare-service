using BE.Dtos;
using BE.Models;
using BE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BE.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserByIdAsync(string id)
        {
            var users = await _userService.GetUserByIdAsync(id);
            return Ok(users);
        }

        [HttpGet("roles/{id}")]
        public async Task<ActionResult<PaginatedResult<UserDto>>> GetUserByRoleIdAsync(string id, int pageNumber, int pageSize)
        {
            var users = await _userService.GetUserByRoleIdAsync(id, pageNumber, pageSize);
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAsync(UserCreateDto userDto)
        {
            try
            {
                var res = await _userService.AddUserAsync(userDto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAsync(string id, UserCreateDto userDto)
        {            
            try
            {
                await _userService.UpdateUserAsync(id, userDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(string id)
        {            
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        [HttpPost("change-password")]
        public async Task<ActionResult> ChangePasswordAsync([FromBody] ChangePasswordDto model)
        {
            try
            {
                await _userService.ChangePasswordAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }            
        }

        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAllRolesAsync()
        {
            var roles = await _userService.GetAllRolesAsync();
            return Ok(roles);
        }
        [HttpPost("roles")]
        public async Task<ActionResult> AddRolesAsync(RoleDto roleDto)
        {
            await _userService.AddRoleAsync(roleDto);
            return Ok(roleDto);
        }

        [HttpPost("UploadCsv")]
        public async Task<ActionResult> UploadCsv(IFormFile file)
        {
            await _userService.UploadCsv(file);
            return Ok();
        }

        [HttpGet("sub-addr/{id}")]
        public async Task<ActionResult<AddressDto>> GetAddressBySubIdAsync(int id)
        {
            return await _userService.GetAddressBySubIdAsync(id);
        }

        [HttpGet("shift")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersByShiftAsync(int shiftId, DateTime shiftDate)
        {
            var users = await _userService.GetUsersByShiftAsync(shiftId, shiftDate);

            if (users == null || !users.Any())
            {
                return NotFound();
            }
            return Ok(users);
        }
    }
}
