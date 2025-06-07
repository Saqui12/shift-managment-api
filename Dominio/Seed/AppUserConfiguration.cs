using Dominio.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace Dominio.Seed
{
    [NotMapped]
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var hasher = new PasswordHasher<AppUser>();
            builder.HasData(
                new AppUser
                {
                    Id = "07bc1990-5e8d-4237-a9e4-8e6b8ba56237",
                    FullName = "Admin1234!",
                    Email = "admin@gmail.com",
                    PasswordHash = "AQAAAAIAAYagAAAAEAiIJOcSduEzjc8bubbyi0gF/7rAz4yYE1sLol2XzqD3Jd/VsmhserCkL44tZExtcA==",
                    UserName = "admin@gmail.com",
                    AccessFailedCount = 0,
                    ConcurrencyStamp = "892bd384-4698-42a8-90e0-2a359e6af3bd",
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    LockoutEnd = null,
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = "e2b5ce7a-c6a1-4c1c-8f9e-2f9212ee73bc",
                    TwoFactorEnabled = false
                },
                new AppUser
                {
                    Id = "03bc1990-5e8d-4237-a9e4-8e6b8ba56237",
                    FullName = "Employee1234!",
                    Email = "employee@gmail.com",
                    PasswordHash = "AQAAAAIAAYagAAAAEPhdcQnNXI8EKVZakKNmRPedmr+sBV1yxeBAeSOAqEvtujsYAgMTQ7Sq2/aZ36mqQg==",
                    UserName = "employee@gmail.com",
                    AccessFailedCount = 0,
                    ConcurrencyStamp = "462bd384-4698-42a8-90e0-2a359e6af3bd",
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    LockoutEnd = null,
                    NormalizedEmail = "EMPLOYEE@GMAIL.COM",
                    NormalizedUserName = "EMPLOYEE@GMAIL.COM",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = "e0b5ce7a-c6a1-4c1c-8f9e-2f9212ee73bc",
                    TwoFactorEnabled = false
                },
                new AppUser
                {
                    Id = "03bc1990-5e8d-4237-a9e4-8e6b8ba56437",
                    FullName = "User1234!",
                    Email = "user@gmail.com",
                    PasswordHash = "AQAAAAIAAYagAAAAEN6erUfNGTWPzpDB0rcvN8mAsr+Oed4PWckqlJPCRUNizdj58HRYN8B9HF9Xc3rSiQ==",
                    UserName = "user@gmail.com",
                    AccessFailedCount = 0,
                    ConcurrencyStamp = "162bd384-4698-42a8-90e0-2a359e6af3bd",
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    LockoutEnd = null,
                    NormalizedEmail = "USER@GMAIL.COM",
                    NormalizedUserName = "USER@GMAIL.COM",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = "e7b5ce7a-c6a1-4c1c-8f9e-2f9212ee73bc",
                    TwoFactorEnabled = false


                }
             
            );
        }


    }


}