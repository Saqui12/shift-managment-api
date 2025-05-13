
using Dominio.Entities;
using Dominio.Interfaces;
using Dominio.Models.Parameters;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Repositories
{
    public class BloqueoRepository : BaseRepository<Bloqueo>, IBloqueoRepository
    {
        public BloqueoRepository(PeloterosDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Bloqueo>> GetFiltered(BloqueoParameters param)
        {
            var query = _context.Bloqueos.AsQueryable();

            if (param.recursoId != Guid.Empty) 
                query = query.Where(x => x.RecursoId == param.recursoId);
            if (!string.IsNullOrEmpty(param.motivo))
                query = query.Where(x => x.Motivo == param.motivo);

            query = query.Where(x => x.Fecha >= param.FechaDesde && x.Fecha <= param.FechaHasta);
            query = query.Where(x => x.HoraInicio >= param.HoraInicio && x.HoraFin <= param.HoraFin);

            query = query.OrderByDescending(x => x.Fecha);

            return await query.AsNoTracking()
                .Skip((param.PageNumber - 1) * param.PageSize)
                .Take(param.PageSize)
                .ToListAsync();
        }
    }
    
    
}
