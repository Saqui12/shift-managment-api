
using Dominio.Entities;
using Dominio.Interfaces;
using Dominio.Models.Parameters;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(PeloterosDbContext context)
            : base(context)
        {
        }
        public async Task<PagedResults<Cliente>> GetAllFilterAsync(ClientesParameters param)
        {
            var query = _context.Clientes.AsQueryable();

            if (!string.IsNullOrEmpty(param.NombreApellidoEmail))
                query = query.Where(x => x.Nombre != null && x.Nombre.ToLower().Contains(param.NombreApellidoEmail.ToLower()) ||
                                         x.Apellido != null && x.Apellido.ToLower().Contains(param.NombreApellidoEmail.ToLower()) ||
                                         x.Email != null && x.Email.ToLower().Contains(param.NombreApellidoEmail.ToLower()));

            var count = await query.CountAsync();
            var clientes = await query.AsNoTracking()
          .OrderByDescending(p => p.FechaRegistro)
          .ThenByDescending(g => g.Turnos.Max(f => f.Fecha))
          .Skip((param.PageNumber - 1) * param.PageSize)
          .Take(param.PageSize)
          .Include(p => p.Turnos.Take(1))
          .ToListAsync();

            return new PagedResults<Cliente>(clientes, count, param.PageNumber, param.PageSize);
        }
    }


}
