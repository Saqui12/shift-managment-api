using Microsoft.AspNetCore.Identity;

namespace Dominio.Entities.Identity
{
    public class AppUser: IdentityUser 
    {
        public string FullName { get; set; }
    }
}
