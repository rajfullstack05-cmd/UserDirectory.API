using UserDirectory.API.DTOs;
using UserDirectory.API.Models;
using UserDirectory.API.Repositories;

namespace UserDirectory.API.Services
{

        public class UserService : IUserService
        {
            private readonly IUserRepository _userRepository;

            public UserService(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            
            public async Task<List<User>> GetAllUsersAsync()
            {
                return await _userRepository.GetAllUsersAsync();
            }

            
            public async Task<User?> GetUserByIdAsync(int id)
            {
                return await _userRepository.GetUserByIdAsync(id);
            }

            
            public async Task<User> AddUserAsync(CreateUserDto request)
            {
                var user = new User
                {
                    Name = request.Name,
                    Age = request.Age,
                    City = request.City,
                    State = request.State,
                    Pincode = request.Pincode
                };

                return await _userRepository.AddUserAsync(user);
            }

            
            public async Task<bool> UpdateUserAsync(
                int id, UpdateUserDto request)
            {
                var user = await _userRepository.GetUserByIdAsync(id);

                if (user == null)
                {
                    return false;
                }

                user.Name = request.Name;
                user.Age = request.Age;
                user.City = request.City;
                user.State = request.State;
                user.Pincode = request.Pincode;

                return await _userRepository.UpdateUserAsync(user);
            }

         
            public async Task<bool> DeleteUserAsync(int id)
            {
                return await _userRepository.DeleteUserAsync(id);
            }
        }
    

}
