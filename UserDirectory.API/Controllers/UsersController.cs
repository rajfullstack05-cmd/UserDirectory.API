using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserDirectory.API.DTOs;
using UserDirectory.API.Services;

namespace UserDirectory.API.Controllers
{

        [Route("api/[controller]")]
        [ApiController]

        public class UsersController : ControllerBase
        {
            private readonly IUserService _userService;

            public UsersController(IUserService userService)
            {
                _userService = userService;
            }

       
            [HttpGet]
            public async Task<IActionResult> GetAllUsers()
            {
                var users = await _userService.GetAllUsersAsync();

                return Ok(users);
            }

            // GET: api/users/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
            {
                var user = await _userService.GetUserByIdAsync(id);

                if (user == null)
                {
                    return NotFound(new
                    {
                        message = "User not found"
                    });
                }

                return Ok(user);
            }

            // POST: api/users
        [HttpPost]
        public async Task<IActionResult> AddUser(
                [FromBody] CreateUserDto request)
            {
                var user = await _userService.AddUserAsync(request);

                return CreatedAtAction(
                    nameof(GetUserById),
                    new { id = user.Id },
                    user
                );
            }

            // PUT: api/users/1
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(
                int id,
                [FromBody] UpdateUserDto request)
            {
                var result = await _userService.UpdateUserAsync(id, request);

                if (!result)
                {
                    return NotFound(new
                    {
                        message = "User not found"
                    });
                }

                return Ok(new
                {
                    message = "User updated successfully"
                });
            }

            // DELETE: api/users/1
            [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int id)
            {
                var result = await _userService.DeleteUserAsync(id);

                if (!result)
                {
                    return NotFound(new
                    {
                        message = "User not found"
                    });
                }

                return Ok(new
                {
                    message = "User deleted successfully"
                });
            }


        }
    

}
