using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IRepositoryManager
    {
        IClienteRepository Cliente { get; }
        IRecursoRepository Recurso { get; }
        ITurnosRepository Turno { get; }
        IUnitOfWork UnitOfWork { get; }
        IPagosRepository Pagos { get; }
        IBloqueoRepository Bloqueo { get; }
        IHorariosDisponibilidadRepository HorariosDisponibilidad { get; }
    }
}
