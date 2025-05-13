using Dominio.Entities;
using Dominio.Models.Parameters;


namespace Dominio.Interfaces
{
    public interface ITurnosRepository: IBaseRepository<Turno>
    {
        Task<IEnumerable<Turno>> GetByWeek(DateOnly week);
        
        Task<IEnumerable<Turno>> GetFiltered(TurnosParameters param); 

    }
}
