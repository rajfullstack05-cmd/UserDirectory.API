using UserDirectory.API.DTOs;
using UserDirectory.API.Models;

namespace UserDirectory.API.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();

        Task<User?> GetUserByIdAsync(int id);

        Task<User> AddUserAsync(CreateUserDto request);

        Task<bool> UpdateUserAsync(int id, UpdateUserDto request);

        Task<bool> DeleteUserAsync(int id);
    }
}
