using Dominio.Entities;
using Dominio.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Seed
{
    [NotMapped]
    public class RecursoConfiguration : IEntityTypeConfiguration<Recurso>
    {
        public void Configure(EntityTypeBuilder<Recurso> builder)
        {
            builder.HasData(
                new Recurso
                {
                    RecursoId = Guid.Parse("07bc1990-5e8d-4237-a9e4-8e6b8ba56537"),
                    Nombre = "Jungla",
                    Descripcion = "Descripcion del recurso 1",
                    Capacidad = 80,
                    PrecioHora = 8000,
                    Activo = true
                },
                new Recurso
                {
                    RecursoId = Guid.Parse("07bc1990-5e8d-4237-a9e4-8e6b8ba88237"),
                    Nombre = "Jump",
                    Descripcion = "Descripcion del recurso 2",
                    Capacidad = 60,
                    PrecioHora = 10000,
                    Activo = true

                }
            );
        }


    }


}