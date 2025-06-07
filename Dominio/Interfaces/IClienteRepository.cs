

using Dominio.Entities;
using Dominio.Models.Parameters;

namespace Dominio.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<PagedResults<Cliente>> GetAllFilterAsync(ClientesParameters param);
    }
}
