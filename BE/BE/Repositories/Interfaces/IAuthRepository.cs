using BE.Dtos;
using BE.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace BE.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<LoginRes> Login(LoginReq request);
        Task<User> Register(UserCreateDto request);
    }
}
