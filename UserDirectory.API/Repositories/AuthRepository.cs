using Azure.Core;
using Microsoft.EntityFrameworkCore;
using UserDirectory.API.Data;
using UserDirectory.API.DTOs;
using UserDirectory.API.Models;

namespace UserDirectory.API.Repositories
{
    public class AuthRepository : IAuthRespository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AuthRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<LoginUsers?> GetUserByIdAsync(LoginRequestDto request
            )
        {

            var user = await _applicationDbContext.LoginUsers
        .FirstOrDefaultAsync(x => x.Email == request.Username);
            return user;

        }
    }
}
