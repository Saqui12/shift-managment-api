using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.Entities;

namespace Dominio.Seed
{
    [NotMapped]
    public class ClientesConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasData(
                new Cliente
                {
                    ClienteId = Guid.Parse("04bc1990-5e8d-4237-a9e4-8e5b8ba56237"),
                    Nombre = "Juan",
                    Apellido = "Pérez",
                    Email = "juanperez@gmail.com",
                    Telefono = "123456789",
                    FechaRegistro = new DateOnly(2025, 05, 10),
                    Activo = true

                },
                new Cliente
                {
                    ClienteId = Guid.Parse("07bc1770-5e8d-4237-a9e4-8e6b8ba56237"),
                    Nombre = "María",
                    Apellido = "Gómez",
                    Email = "maria@gmail.com",
                    Telefono = "987654321",
                    FechaRegistro = new DateOnly(2025,05,01),
                    Activo = true
                }
                , new Cliente
                {
                    ClienteId = Guid.Parse("04bc1990-5e8d-4237-a9e4-6e6b8ba76237"),
                    Nombre = "Pedro",
                    Apellido = "López",
                    Email = "pedro@gmail.com",
                    Telefono = "456789123",
                    FechaRegistro = new DateOnly(2025, 05, 03),
                    Activo = true
                }
                );
              
        }


    }
}
