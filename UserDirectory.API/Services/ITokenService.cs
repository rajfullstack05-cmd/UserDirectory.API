using UserDirectory.API.Models;

namespace UserDirectory.API.Services
{
    public interface ITokenService
    {
        Task<string> GenerateToken(LoginUsers user);
    }
}
