using Dominio.Models.Parameters;   
using Dominio.Entities;
using Dominio.Interfaces;
using Infrastructure.Data;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;


namespace Infrastructure.Repositories
{
    public class TurnoRepository : BaseRepository<Turno>, ITurnosRepository
    {
        public TurnoRepository(PeloterosDbContext context)
            : base(context)
        { }
        public async Task<IEnumerable<Turno>> GetOverShift(Guid recursoId,DateOnly fecha, TimeOnly horaInicio, TimeOnly horaFinal)
        {
            ;
            return await _context.Turnos
                .AsNoTracking()
                .Where(x => x.Fecha == fecha &&
                            x.Recurso.RecursoId == recursoId &&
                            x.HoraInicio < horaFinal &&
                            x.HoraFin > horaInicio)
                .ToListAsync();
        }
        public async Task<PagedResults<Turno>> GetFiltered(TurnosParameters param)
        {
            var query = _context.Turnos.AsQueryable();

            if(!string.IsNullOrEmpty(param.Estado))
                query= query.Where(x => x.Estado!.ToLower().Contains(param.Estado.ToLower()));
            if (!string.IsNullOrEmpty(param.NombreApellidoCliente))
                query = query.Where(x => x.Cliente.Apellido.ToLower().Contains(param.NombreApellidoCliente.ToLower())
                                        || x.Cliente.Nombre.ToLower().Contains(param.NombreApellidoCliente.ToLower()));
            if (param.Recurso!= null)
                query = query.Where(x => x.Recurso.RecursoId == param.Recurso);

            query = query.Where(x => x.Fecha >= param.FechaDesde && x.Fecha <= param.FechaHasta);
            query = query.Where(x => x.HoraInicio >= param.HoraInicio && x.HoraFin <=param.HoraFin);

            if (!string.IsNullOrEmpty(param.OrderBy))
            {
                var orderQuery = param.OrderBy + " descending";
                query = query.OrderBy(orderQuery);
            }
             
                var count = await query.CountAsync();

               var item= await query.AsNoTracking()
                .Skip((param.PageNumber-1)*param.PageSize)
                .Take(param.PageSize)
                .Include(t => t.Cliente)
                .Include(p => p.Recurso)
                .ToListAsync();



            return new PagedResults<Turno>(item, count, param.PageNumber, param.PageSize);
   
        }
    }


}
