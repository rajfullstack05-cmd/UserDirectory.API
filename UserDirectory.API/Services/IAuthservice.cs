using UserDirectory.API.DTOs;
using UserDirectory.API.Models;

namespace UserDirectory.API.Services
{
    public interface IAuthservice
    {
        Task<LoginUsers> GetUsersAsync(LoginRequestDto request);
     
    }
}
