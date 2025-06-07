using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Dominio.Entities;

namespace Dominio.Seed
{
    public class TurnosConfiguration : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {
            builder.HasData(
                
                new Turno
                {
                    TurnoId = Guid.Parse("05bc1990-5e8d-4237-a9e4-8e5b8ba56431"),
                    ClienteId = Guid.Parse("04bc1990-5e8d-4237-a9e4-8e5b8ba56237"),
                    RecursoId = Guid.Parse("07bc1990-5e8d-4237-a9e4-8e6b8ba56537"),
                    Fecha = new DateOnly(2025, 5, 17),
                    HoraInicio = new TimeOnly(9, 0),
                    HoraFin = new TimeOnly(10, 0),
                    Estado = "Reservado",
                    MontoTotal = 1000,
                    FechaReserva = new DateTime(2025,5,17),
                    Notas = ""
                },
                new Turno
                {
                    TurnoId = Guid.Parse("06bc1990-5e8d-4237-a9e4-8e5b8ba56437"),
                    ClienteId = Guid.Parse("07bc1770-5e8d-4237-a9e4-8e6b8ba56237"),
                    RecursoId = Guid.Parse("07bc1990-5e8d-4237-a9e4-8e6b8ba88237"),
                    Fecha = new DateOnly(2025, 5, 18),
                    HoraInicio = new TimeOnly(10, 0),
                    HoraFin = new TimeOnly(12, 0),
                    Estado = "Reservado",
                    MontoTotal = 2000,
                    FechaReserva = new DateTime(2025, 5, 18),
                    Notas = ""
                }

                );

        }
    }
}
