using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserDirectory.API.DTOs;
using UserDirectory.API.Models;
using UserDirectory.API.Services;

namespace UserDirectory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthservice _authservice;
        private readonly ITokenService _tokenservice;
        public AuthController(IAuthservice authservice,ITokenService tokenService)
        {
            _authservice = authservice;
            _tokenservice = tokenService;
        }
        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var user = await _authservice.GetUsersAsync(request);
            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid username or password."
                });
            }
            var token = await _tokenservice.GenerateToken(user);
            var expiresAt = DateTime.UtcNow.AddMinutes(60);

            var response = new LoginResponseDto
            {
                AccessToken = token,
                TokenType = "Bearer",
                ExpiresAt = expiresAt,
                User = new UserResponseDto
                {
                    Name = user.Name,
                    Email = user.Email,
                    Role = user.Role
                }
            };

            return Ok(response);
        }
    }
}