namespace Application.Services.DTOs.User
{
    public class CreateUser : UserBase
    {
        public required string ConfirmPassword  { get; set; }
        public required string FullName { get; set; }
    }
}
