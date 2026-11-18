using UserDirectory.API.DTOs;
using UserDirectory.API.Models;

namespace UserDirectory.API.Repositories
{
    public interface IAuthRespository
    {
        Task<LoginUsers> GetUserByIdAsync(LoginRequestDto loginRequestDto);
    }
}
