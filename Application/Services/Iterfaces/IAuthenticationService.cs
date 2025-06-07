using Application.Services.DTOs;
using Application.Services.DTOs.Auth;
using Application.Services.DTOs.User;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Application.Services.Iterfaces
{
    public interface IAuthenticationService
    {
        Task<ServiceResponse> Register(CreateUser createuser);
        Task<LoginResponse> Login(LoginUser loginUser);
        Task<LoginResponse> RenewToken( string refreshToken);
        Task<ServiceResponse> DeleteUser(string email);
        Task<ServiceResponseData> Update(string id ,UpdateUser updateUser);
        Task<ServiceResponseData> GetByEmail(string email);
        Task<AuthenticatedUserDto> GetAuthenticatedUserAsync(ClaimsPrincipal user);
        Task<string?> GetRoleIdByEmail(string email);
        Task<bool> AddUserToRole(string userid, string role);
        Task<IEnumerable<UserDto>> GetAllUser();
        Task<IdentityResult> ResetPassword(string id, PasswordResetDto password);

    }
}
