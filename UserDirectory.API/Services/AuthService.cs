using Microsoft.AspNetCore.Identity;
using UserDirectory.API.DTOs;
using UserDirectory.API.Models;
using UserDirectory.API.Repositories;

namespace UserDirectory.API.Services
{
    public class AuthService : IAuthservice
    {
        private  readonly IAuthRespository _authRespository;
        private readonly ITokenService _tokenService;
        public AuthService(IAuthRespository authRespository, ITokenService tokenService)
        {
         _authRespository = authRespository;   
         _tokenService = tokenService;  
        }
        public async Task<LoginUsers?> GetUsersAsync(LoginRequestDto request)
        {
            var userdetails= await _authRespository.GetUserByIdAsync(request);
       
            if (userdetails == null || !userdetails.IsActive)
                return null;
           var  PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(
                  request.Password,
                  userdetails.PasswordHash
              );
            if (!isPasswordValid)
                return null;


            return userdetails;
        }

     
    }
}
