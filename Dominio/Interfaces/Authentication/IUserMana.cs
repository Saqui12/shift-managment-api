using Dominio.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Dominio.Interfaces.Authentication
{
    public interface IUserMana
    {
        Task<AppUser?> GetUserByEmail(string email);
        Task<AppUser> GetUserById(string id);
        Task<bool> CreateUser(AppUser user);
        Task<bool> LoginUser(string email, string password);
        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<bool> DeleteUserByEmail(string email);
        Task<List<Claim>> GetUserClaims(string email);
        Task<AppUser> UpdateUser(AppUser user);
        Task<string> GeneratePasswordResetToken(AppUser user);
        Task<IdentityResult> ResetPassword(AppUser user, string token, string password);
    }
}
