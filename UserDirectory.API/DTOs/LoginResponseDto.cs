namespace UserDirectory.API.DTOs
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; } = string.Empty;

        public string TokenType { get; set; } = "Bearer";

        public DateTime ExpiresAt { get; set; }

        public UserResponseDto User { get; set; } = new();
    }
}
