
using Dominio.Entities;
using Dominio.Interfaces;
using Dominio.Models.Parameters;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BloqueoRepository : BaseRepository<Bloqueo>, IBloqueoRepository
    {
        public BloqueoRepository(PeloterosDbContext context)
            : base(context)
        {
        }
        public async Task<IEnumerable<Bloqueo>> GetOverBloqueo(Guid recursoId, DateOnly fecha, TimeOnly horaInicio, TimeOnly horaFinal)
        {
            ;
            return await _context.Bloqueos
                .AsNoTracking()
                .Where(x => x.Fecha == fecha &&
                            x.RecursoId == recursoId &&
                            x.HoraInicio < horaFinal &&
                            x.HoraFin > horaInicio)
                .ToListAsync();
        }

        public async Task<PagedResults<Bloqueo>> GetFiltered(BloqueoParameters param)
        {
            var query = _context.Bloqueos.AsQueryable();

            if (param.recursoId != Guid.Empty) 
                query = query.Where(x => x.RecursoId == param.recursoId);
            if (!string.IsNullOrEmpty(param.motivo))
                query = query.Where(x => x.Motivo!.ToLower().Contains( param.motivo.ToLower()));

            query = query.Where(x => x.Fecha >= param.FechaDesde && x.Fecha <= param.FechaHasta);
            query = query.Where(x => x.HoraInicio >= param.HoraInicio && x.HoraFin <= param.HoraFin);

            query = query.OrderByDescending(x => x.Fecha);
            var count = await query.CountAsync();
            var bloqueos=   await query.AsNoTracking()
                .Skip((param.PageNumber - 1) * param.PageSize)
                .Take(param.PageSize)
                .ToListAsync();
            
            return new PagedResults<Bloqueo>(bloqueos, count, param.PageNumber, param.PageSize);
        }
    }
    
    
}
