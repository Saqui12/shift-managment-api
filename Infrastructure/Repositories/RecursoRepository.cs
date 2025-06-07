
using Dominio.Entities;
using Dominio.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RecursoRepository : BaseRepository<Recurso>, IRecursoRepository
    {
        public RecursoRepository(PeloterosDbContext context)
            : base(context)
        {
        }

        public async override Task<IEnumerable<Recurso>>  GetAllAsync()
        {
            return await _context.Recursos.AsNoTracking()
                .Include(r => r.HorariosDisponibilidad)
                .ToListAsync();
        }
    }
    
    
}
