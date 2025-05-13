

using Dominio.Entities;
using Dominio.Models.Parameters;

namespace Dominio.Interfaces
{
    public interface IBloqueoRepository : IBaseRepository<Bloqueo>
    {
        Task<IEnumerable<Bloqueo>> GetFiltered(BloqueoParameters param);
    }
}
