
using Dominio.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class RepositoryManager(PeloterosDbContext _contexto) : IRepositoryManager
    {
        private IClienteRepository? _clienteRepository;
        private IRecursoRepository? _recursoRepository;
        private ITurnosRepository? _turnoRepository;
        private IUnitOfWork? _unitOfWork;
        private IBloqueoRepository? _bloqueoRepository;
        private IHorariosDisponibilidadRepository? _disponiblerepository;
        private IPagosRepository? _pagosRepository;

        public IPagosRepository Pagos
        {
            get
            {
                if (_pagosRepository == null)
                {
                    _pagosRepository = new PagosRepository(_contexto);
                }
                return _pagosRepository;
            }
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (_unitOfWork == null)
                {
                    _unitOfWork = new UnitOfWork(_contexto);
                }
                return _unitOfWork;

             }

        }
        public IBloqueoRepository Bloqueo
        {
            get
            {
                if (_bloqueoRepository == null)
                {
                    _bloqueoRepository = new BloqueoRepository(_contexto);
                }
                return _bloqueoRepository;
            }
        }
        public IHorariosDisponibilidadRepository HorariosDisponibilidad
        {
            get
            {
                if (_disponiblerepository == null)
                {
                    _disponiblerepository = new HorariosDisponiblesRespository(_contexto);
                }
                return _disponiblerepository;
            }
        }
        public IClienteRepository Cliente
        {
            get
            {
                if (_clienteRepository == null)
                {
                    _clienteRepository = new ClienteRepository(_contexto);
                }
                return _clienteRepository;
            }
        }

        public IRecursoRepository Recurso
        {
            get
            {
                if (_recursoRepository == null)
                {
                    _recursoRepository = new RecursoRepository(_contexto);
                }
                return _recursoRepository;
            }
        }
        public ITurnosRepository Turno
        {
            get
            {
                if (_turnoRepository == null)
                {
                    _turnoRepository = new TurnoRepository(_contexto);
                }
                return _turnoRepository;
            }
        }
    
    }
}
