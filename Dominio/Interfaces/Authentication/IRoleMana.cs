using Dominio.Entities.Identity;

namespace Dominio.Interfaces.Authentication
{
    public interface IRoleMana
    {
        Task<string?> GetRoleIdByEmail(string email);
        Task<bool> AddUserToRole(AppUser user, string roleName);
    }
}
