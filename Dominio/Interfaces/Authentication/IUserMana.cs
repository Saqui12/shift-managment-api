using Dominio.Entities.Identity;
using System.Security.Claims;

namespace Dominio.Interfaces.Authentication
{
    public interface IUserMana
    {
        Task<AppUser?> GetUserByEmail(string email);
        Task<AppUser> GetUserById(string id);
        Task<bool> CreateUser(AppUser user);
        Task<bool> LoginUser(AppUser user);
        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<bool> DeleteUserByEmail(string email);
        Task<List<Claim>> GetUserClaims(string email);
        Task<AppUser> UpdateUser(AppUser user);
    }
}
