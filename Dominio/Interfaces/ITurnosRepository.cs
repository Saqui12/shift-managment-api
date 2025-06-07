using Dominio.Entities;
using Dominio.Models.Parameters;


namespace Dominio.Interfaces
{
    public interface ITurnosRepository: IBaseRepository<Turno>
    {
        Task<IEnumerable<Turno>> GetOverShift(Guid recursoId, DateOnly fecha, TimeOnly horaInicio, TimeOnly horaFinal);
        Task<PagedResults<Turno>> GetFiltered(TurnosParameters param); 

    }
}
