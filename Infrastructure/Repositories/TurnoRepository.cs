using Dominio.Models.Parameters;   
using Dominio.Entities;
using Dominio.Interfaces;
using Infrastructure.Data;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using System;


namespace Infrastructure.Repositories
{
    public class TurnoRepository : BaseRepository<Turno>, ITurnosRepository
    {
        public TurnoRepository(PeloterosDbContext context)
            : base(context)
        { }
        public async Task<IEnumerable<Turno>> GetByWeek(DateOnly week)
        {


            return await _context.Turnos
                .Where(x => x.Fecha >= week && x.Fecha <=week.AddDays(7))
                .Include(p=>p.Cliente)
                .ToListAsync();
        }
        public async Task<IEnumerable<Turno>> GetFiltered(TurnosParameters param)
        {
            var query = _context.Turnos.AsQueryable();

            if(!string.IsNullOrEmpty(param.Estado))
                query= query.Where(x => x.Estado == param.Estado);
            if (!string.IsNullOrEmpty(param.ApellidoCliente))
                query = query.Where(x => x.Cliente.Apellido == param.ApellidoCliente);
            if (!string.IsNullOrEmpty(param.Recurso))
                query = query.Where(x => x.Recurso.Nombre == param.Recurso);

            query = query.Where(x => x.Fecha >= param.FechaDesde && x.Fecha <= param.FechaHasta);
            query = query.Where(x => x.HoraInicio >= param.HoraInicio && x.HoraFin <=param.HoraFin);

            if (!string.IsNullOrEmpty(param.OrderBy))
            {
                var orderQuery = param.OrderBy + " descending";
                query = query.OrderBy(orderQuery);
            }
                
                return await query.AsNoTracking()
                .Skip((param.PageNumber-1)*param.PageSize)
                .Take(param.PageSize)
                .Include(t => t.Cliente)
                .Include(p => p.Recurso)
                .ToListAsync();
        }
    }


}
