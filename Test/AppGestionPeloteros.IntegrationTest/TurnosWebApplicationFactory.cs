using Dominio.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Test.AppGestionPeloteros.IntegrationTest
{
    public class TurnosWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceDescriptors = services.Where(
           d => d.ServiceType.Name.Contains("DbContext") ||
                d.ImplementationType?.Name.Contains("DbContext") == true ||
                d.ServiceType.Namespace?.StartsWith("Microsoft.EntityFrameworkCore") == true ||
                d.ImplementationType?.Namespace?.StartsWith("Microsoft.EntityFrameworkCore") == true)
           .ToList();

                foreach (var descriptor in serviceDescriptors)
                {
                    services.Remove(descriptor);
                }
                services.AddDbContext<PeloterosDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTest");
                });

                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<PeloterosDbContext>();

                try
                {

                    db.Database.EnsureCreated();

                    SeedData(db);

                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while seeding the database: {ex.Message}", ex);

                }
            });
        }
        private void SeedData(PeloterosDbContext db)
        {
            // Example of seeding data into the database
            if (!db.Turnos.Any())
            {
                db.Turnos.AddRange(
                    new Turno {
                        RecursoId = Guid.Parse("07bc1990-5e8d-4237-a9e4-8e6b8ba56537"),
                        TurnoId = Guid.NewGuid(),
                        ClienteId = Guid.Parse("04bc1990-5e8d-4237-a9e4-8e5b8ba56237"),
                        Fecha = new DateOnly(2025, 05, 08),
                        HoraInicio = new TimeOnly(10, 0),
                        HoraFin = new TimeOnly(12, 0),
                        Estado = "confirmado",
                        MontoTotal = 1000,
                        Notas = "Test note",

                    },
                     new Turno
                     {
                         RecursoId = Guid.Parse("07bc1990-5e8d-4237-a9e4-8e6b8ba56537"),
                         TurnoId = Guid.Parse("08bc1990-5e8d-4237-a9e4-8e6b8ba56937"),
                         ClienteId = Guid.Parse("04bc1990-5e8d-4237-a9e4-8e5b8ba56237"),
                         Fecha = new DateOnly(2025, 04, 15),
                         HoraInicio = new TimeOnly(20, 0),
                         HoraFin = new TimeOnly(18, 0),
                         Estado = "completado",
                         MontoTotal = 1000,
                         Notas = "Test note",

                     }
                );

                db.SaveChanges();
            }

        }
    }
}
