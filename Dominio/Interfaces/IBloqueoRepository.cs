

using Dominio.Entities;
using Dominio.Models.Parameters;

namespace Dominio.Interfaces
{
    public interface IBloqueoRepository : IBaseRepository<Bloqueo>
    {
        Task<PagedResults<Bloqueo>> GetFiltered(BloqueoParameters param);
        Task<IEnumerable<Bloqueo>> GetOverBloqueo(Guid recursoId, DateOnly fecha, TimeOnly horaInicio, TimeOnly horaFinal);
    }
}
