using Dominio.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Dominio.Seed
{
    [NotMapped]
    public class HorariosDisponibilidadConfiguration : IEntityTypeConfiguration<HorariosDisponibilidad>
    {
        public void Configure(EntityTypeBuilder<HorariosDisponibilidad> builder)
        {
            builder.HasData(
                new HorariosDisponibilidad
                {
                    HorariosDisponibilidadId = Guid.Parse("07bc1990-5e8d-4237-a9e4-4e6b5ba36537"),
                    RecursoId =Guid.Parse("07bc1990-5e8d-4237-a9e4-8e6b8ba56537"),
                    DiaSemana = "Monday",
                    HoraApertura = new TimeOnly(8, 0),
                    HoraCierre = new TimeOnly(20, 0)

                },
                 new HorariosDisponibilidad
                 {
                     HorariosDisponibilidadId = Guid.Parse("07bc1990-5e8d-4237-a9e4-8e6b8ba56739"),
                     RecursoId = Guid.Parse("07bc1990-5e8d-4237-a9e4-8e6b8ba56537"),
                     DiaSemana = "Tuesday",
                     HoraApertura = new TimeOnly(8, 0),
                     HoraCierre = new TimeOnly(20, 0)

                 },
                  new HorariosDisponibilidad
                  {
                      HorariosDisponibilidadId = Guid.Parse("07bc1990-5e8d-4237-a9e4-8e6b8ba51237"),
                      RecursoId = Guid.Parse("07bc1990-5e8d-4237-a9e4-8e6b8ba56537"),
                      DiaSemana = "Wednesday",
                      HoraApertura = new TimeOnly(8, 0),
                      HoraCierre = new TimeOnly(20, 0)

                  },
                   new HorariosDisponibilidad
                   {
                       HorariosDisponibilidadId = Guid.Parse("07bc1990-5e8d-5237-a3e4-8e6b8ba56537"),
                       RecursoId = Guid.Parse("07bc1990-5e8d-4237-a9e4-8e6b8ba56537"),
                       DiaSemana = "Thursday",
                       HoraApertura = new TimeOnly(8, 0),
                       HoraCierre = new TimeOnly(20, 0)

                   },
                    new HorariosDisponibilidad
                    {
                        HorariosDisponibilidadId = Guid.Parse("03bc1990-5e8d-4237-a9e4-2e6b8ba56537"),
                        RecursoId = Guid.Parse("07bc1990-5e8d-4237-a9e4-8e6b8ba56537"),
                        DiaSemana = "Friday",
                        HoraApertura = new TimeOnly(8, 0),
                        HoraCierre = new TimeOnly(20, 0)

                    }
                );

        }


    }
}
