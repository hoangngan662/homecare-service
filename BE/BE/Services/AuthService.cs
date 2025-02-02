using BE.Dtos;
using BE.Models;
using BE.Repositories.Interfaces;

namespace BE.Services
{
    public class AuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<User> Register(UserCreateDto req)
        {
            return await _authRepository.Register(req);
        }

        public async Task<LoginRes> Login(LoginReq req)
        {
            return await _authRepository.Login(req);
        }
    }
}
