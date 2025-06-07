using Microsoft.AspNetCore.Identity;

namespace Dominio.Entities.Identity
{
    public class AppUser: IdentityUser 
    {

        //public string? Surname { get; set; }
        //public string? Address { get; set; }
        public string? FullName { get; set; }
    }
}
