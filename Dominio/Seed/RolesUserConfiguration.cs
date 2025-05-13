using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dominio.Seed
{
    public class RolesUserConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "07bc1340-5e8d-4237-a9e4-8e6b8ba56237", //admin
                    UserId ="07bc1990-5e8d-4237-a9e4-8e6b8ba56237"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "078a1ad8e-302a-4e75-a156-f997bb40d131", //employee
                    UserId = "078a1ad8e-302a-4e75-a156-f997bb40d131"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "596fd05b-7d8c-4c8d-aef1-c50dae89977a", //user
                    UserId = "079a1rd8e-302a-4e75-a156-f997bb40d131"


                }
            );
        }
    }
}
