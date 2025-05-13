using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entities.Identity
{
    [NotMapped]
    public class RolesConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "07bc1340-5e8d-4237-a9e4-8e6b8ba56237",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "078a1ad8e-302a-4e75-a156-f997bb40d131",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "596fd05b-7d8c-4c8d-aef1-c50dae89977a",
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        }


    }   
    
    
}
