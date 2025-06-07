using Dominio.Entities.Identity;
using Dominio.Interfaces.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories.Authentication
{
    public class RoleMana(UserManager<AppUser> usermanager) : IRoleMana
    {
        public async Task<bool> AddUserToRole(AppUser user, string roleName)
        {
            return (await usermanager.AddToRoleAsync(user, roleName)).Succeeded;
        }
        public async Task<bool> DeleteUserRole(AppUser user, string roleName)
        {
            return(await usermanager.RemoveFromRoleAsync(user, roleName)).Succeeded;
        }

        public async Task<string?> GetRoleIdByEmail(string email)
        {
            var user= await usermanager.FindByEmailAsync(email);
            return user != null ? (await usermanager.GetRolesAsync(user)).FirstOrDefault() : null;
        }
    }
}
