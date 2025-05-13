
using Dominio.Entities;
using Dominio.Interfaces;
using Dominio.Models.Parameters;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(PeloterosDbContext context)
            : base(context)
        {
        }
        public async Task<IEnumerable<Cliente>> GetAllFilterAsync(ClientesParameters param)
        {
            var query = _context.Clientes.AsQueryable();

            if (!string.IsNullOrEmpty(param.Apellido))
                query = query.Where(x => x.Apellido == param.Apellido);
            if (!string.IsNullOrEmpty(param.Nombre))
                query = query.Where(x => x.Nombre == param.Nombre);
            if (!string.IsNullOrEmpty(param.Email))
                query = query.Where(x => x.Email == param.Email);



            return await query.AsNoTracking()
                .OrderByDescending(p => p.FechaRegistro)
                .ThenByDescending(g => g.Turnos.Max(f => f.Fecha))
                .Skip((param.PageNumber - 1) * param.PageSize)
                .Take(param.PageSize)
                .Include(p => p.Turnos)
                .ToListAsync();
        }
    } 
    
    
}
