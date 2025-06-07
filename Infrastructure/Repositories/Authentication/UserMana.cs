using Dominio.Entities.Identity;
using Dominio.Interfaces.Authentication;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Infrastructure.Repositories.Authentication
{
    public class UserMana(UserManager<AppUser> usermanager, IRoleMana rolemanager) : IUserMana
    {
     
        public async Task<bool> CreateUser(AppUser user)
        {
            AppUser? _user = await GetUserByEmail(user.Email!);
            if (_user != null)
                throw new ArgumentException("User already exists");

            return (await usermanager.CreateAsync(user!, user!.PasswordHash!)).Succeeded;
        }
        public async Task<IEnumerable<AppUser>> GetAllUsers() => await usermanager.Users.ToListAsync();

        public async Task<AppUser?> GetUserByEmail(string email) => await usermanager.FindByEmailAsync(email);

        public async Task<AppUser> GetUserById(string id) => await usermanager.FindByIdAsync(id);

        public async Task<List<Claim>> GetUserClaims(string email)
        {
            var user = await GetUserByEmail(email);
            string? rolename = await rolemanager.GetRoleIdByEmail(user!.Email!);
            List<Claim> claim = [
                new Claim("FullName",user.FullName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Role, rolename!)
                ];
            return claim;
        }
        public async Task<bool> DeleteUserByEmail(string email)
        {
            var user = await usermanager.FindByEmailAsync(email);
            if (user is null)
                return false;

            return (await usermanager.DeleteAsync(user)).Succeeded;

        }
        public async Task<AppUser> UpdateUser(AppUser user)
        {
            var _user = await GetUserByEmail(user.Email!);
            if (_user is null)
                throw new ArgumentException("User not found");

            _user.FullName = user.FullName;
            _user.PhoneNumber = user.PhoneNumber;
            _user.UserName = user.UserName;
            _user.NormalizedUserName = user.NormalizedUserName;
            _user.NormalizedEmail = user.NormalizedEmail;
            return (await usermanager.UpdateAsync(_user)).Succeeded ? _user : null!;
        }

        public async Task<bool> LoginUser(string email , string password)
        {
            var _user = await usermanager.FindByEmailAsync(email);
            if (_user is null)
                return false;

            string? Rolename = await rolemanager.GetRoleIdByEmail(email);
            if (Rolename is null) return false;

            return await usermanager.CheckPasswordAsync(_user, password);

        }
        public async Task<AppUser> UpdateUserAsync(AppUser user)
        {
            return (await usermanager.UpdateAsync(user)).Succeeded ? user : null!;
        }

        public async Task<string> GeneratePasswordResetToken(AppUser user) =>  await usermanager.GeneratePasswordResetTokenAsync(user);
        public async Task<IdentityResult> ResetPassword(AppUser user, string token, string password)
        {
            var result =await usermanager.ResetPasswordAsync(user, token, password);
            return result;
        }
        
    }
}
