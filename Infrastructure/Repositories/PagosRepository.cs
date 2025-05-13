
using Application.Services.DTOs.Pago;
using Dominio.Entities;
using Dominio.Interfaces;
using Dominio.Models.Parameters;
using Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public  class PagosRepository: BaseRepository<Pago>, IPagosRepository
    {
        public PagosRepository(PeloterosDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Pago>> GetAllFilterAsync(PagosParameters param)
        {
            var query = _context.Pagos.AsQueryable();

            if (!string.IsNullOrEmpty(param.ApellidoCliente))
                query = query.Where(x => x.Turno.Cliente.Apellido == param.ApellidoCliente);
            if(!string.IsNullOrEmpty(param.Estado))
                query = query.Where(x => x.Estado == param.Estado);

           //   query = query.Where(x => x.FechaPago >= param.FechaDesde && x.FechaPago <= param.FechaHasta);

            return await query.AsNoTracking()              
                .OrderByDescending(p => p.FechaPago)
                .ThenByDescending(g => g.Turno.HoraInicio)
                .Skip((param.PageNumber - 1) * param.PageSize)
                .Take(param.PageSize)
                .Include(p => p.Turno)
                 .ThenInclude(t => t.Cliente)
                .ToListAsync();
        }
    }

}
