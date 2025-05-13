using Dominio.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Test.AppGestionPeloteros.UnitTest.Repository
{

    public class TurnosRepositoryTest
    { 
        private readonly PeloterosDbContext _context;
        private readonly TurnoRepository _repository;

        public TurnosRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<PeloterosDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
                .Options;

            _context = new PeloterosDbContext(options);
            _repository = new TurnoRepository(_context);
        }
       



        [Fact]
        public async Task GetByWeek_ReturnsTurnos()
        {
            // Arrange
            var week = new DateOnly(2025, 5, 5);

            var cliente = new Cliente { ClienteId = Guid.NewGuid(), Nombre = "Test", Apellido = "", Email = "" };
            _context.Clientes.Add(cliente);

            _context.Turnos.AddRange(
                new Turno { TurnoId = Guid.NewGuid(), FechaReserva = DateTime.Now, Fecha = week, Cliente = cliente },
                new Turno { TurnoId = Guid.NewGuid(), FechaReserva = DateTime.Now, Fecha = week.AddDays(1), Cliente = cliente },
                new Turno { TurnoId = Guid.NewGuid(), FechaReserva = DateTime.Now, Fecha = week.AddDays(-2), Cliente = cliente }
            );
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetByWeek(week);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            _context.Dispose();
        }

        
    }
}
