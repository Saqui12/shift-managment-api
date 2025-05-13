

using Dominio.Entities;
using Dominio.Models.Parameters;

namespace Dominio.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> GetAllFilterAsync(ClientesParameters param);
    }
}
