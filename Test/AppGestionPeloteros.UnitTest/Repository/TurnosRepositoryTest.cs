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

        
    }
}
