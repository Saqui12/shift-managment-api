
using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IHorariosDisponibilidadRepository : IBaseRepository<HorariosDisponibilidad>
    {
        Task<bool> HorarioEstaDisponible(string DiadeSemana, TimeOnly horaInicio, TimeOnly horaFinal);
    }
}
