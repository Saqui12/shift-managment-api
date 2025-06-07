namespace Application.Services.DTOs.Auth
{
    public class PasswordResetDto
    {
        public string newPassword { get; set; }
        public string oldPassword { get; set; }
    }
}
