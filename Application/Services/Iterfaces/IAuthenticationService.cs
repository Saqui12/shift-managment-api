using Application.Services.DTOs;
using Application.Services.DTOs.User;

namespace Application.Services.Iterfaces
{
    public interface IAuthenticationService
    {
        Task<ServiceResponse> Register(CreateUser createuser);
        Task<LoginResponse> Login(LoginUser loginUser);
        Task<LoginResponse> RenewToken( string refreshToken);
        Task<ServiceResponse> DeleteUser(string email);
        Task<ServiceResponseData> Update(UpdateUser updateUser);
        Task<ServiceResponseData> GetByEmail(string email);
       
    }
}
