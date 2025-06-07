
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
        public async Task<Pago?> GetByTurnoIdAsync(Guid id)
        {
            return await _context.Pagos
                              .AsNoTracking()
                              .FirstOrDefaultAsync(p => p.TurnoId == id);
        } 

        public async Task<PagedResults<Pago>> GetAllFilterAsync(PagosParameters param)
        {
            var query = _context.Pagos.AsQueryable();

            if (!string.IsNullOrEmpty(param.NombreApellidoCliente))
                query = query.Where(x => x.Turno.Cliente.Apellido.ToLower().Contains(param.NombreApellidoCliente.ToLower())
                                      || x.Turno.Cliente.Nombre.ToLower().Contains(param.NombreApellidoCliente.ToLower()));
            
            if(!string.IsNullOrEmpty(param.Estado))
                query = query.Where(x => x.Estado!.ToLower().Contains(param.Estado.ToLower()));
           
            if (!string.IsNullOrEmpty(param.MetodoPago))
                query = query.Where(x => x.MetodoPago.ToLower().Contains(param.MetodoPago.ToLower()));

              query = query.Where(x => x.FechaPago >= param.FechaDesde && x.FechaPago <= param.FechaHasta);

              query = query.Where(x => x.Monto >= param.MontoDesde && x.Monto <= param.MontoHasta);


            var count= await query.CountAsync();
            var items =await query.AsNoTracking()              
                .OrderByDescending(p => p.FechaPago)
                .ThenByDescending(g => g.Turno.HoraInicio)
                .Skip((param.PageNumber - 1) * param.PageSize)
                .Take(param.PageSize)
                .Include(p => p.Turno)
                 .ThenInclude(t => t.Cliente)
                .ToListAsync();
            return new PagedResults<Pago>(items, count, param.PageNumber, param.PageSize);
        }
    }

}
