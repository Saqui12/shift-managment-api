using Application.Helper;
using Application.Services.DTOs;
using Application.Services.DTOs.Cliente;
using Application.Services.DTOs.Pago;
using Application.Services.DTOs.Turno;
using Application.Services.Iterfaces;
using Application.Services.Validators.Iterface;
using Dominio.Entities;
using Dominio.Interfaces;
using Dominio.Models.Parameters;
using FluentValidation;
using MapsterMapper;




namespace Application.Services.Implementation
{
    public class TurnoService(IRepositoryManager _manager, IMapper _mapper,
            IValidator<PagoCreationDto> createPago,
            IValidator<ClienteCreationDto> createuserValidator,
            IValidator<TurnoCreationDto> createTurnoValidator,
            IValidationService _validation) : ITurnoService
    {
        // Ask for clientid , if doesnt exist, creat one. If exist go on
        public async Task<TurnoDto> CreateAsync(TurnoCompletoDto turnoCompleto, CancellationToken cancellationToken = default)
        {

            if (turnoCompleto.Turnocreation is null || turnoCompleto.Pagocreation is null)
                throw new ArgumentException("Debe insertar los valores del turno y del pago");

            await _validation.ValidateAsync(turnoCompleto.Turnocreation, createTurnoValidator);
            await _validation.ValidateAsync(turnoCompleto.Pagocreation, createPago);

            //check if the recurso is active
            var recurso = await _manager.Recurso.GetByIdAsync(turnoCompleto.Turnocreation.RecursoId);
            if (!recurso.Activo)
                throw new ArgumentException($"{recurso.Nombre} se encuentra fuera de servicio en el turno solicitado");

            //check if the recurso is available
            var dia = turnoCompleto.Turnocreation.Fecha.DayOfWeek;
            var recursoDisponible = await _manager.HorariosDisponibilidad.HorarioEstaDisponible(dia.ToString(), turnoCompleto.Turnocreation.HoraInicio, turnoCompleto.Turnocreation.HoraFin);
            if (!recursoDisponible)
                throw new ArgumentException($"{recurso.Nombre} no se encuentra abierto al publico en el horario o dia solicitado");

            //check there is no other turnos in the same time
            var turnoLibre = await _manager.Turno.GetFiltered(new TurnosParameters
            {
                FechaDesde = turnoCompleto.Turnocreation.Fecha,
                FechaHasta = turnoCompleto.Turnocreation.Fecha,
                HoraInicio = turnoCompleto.Turnocreation.HoraInicio,
                HoraFin = turnoCompleto.Turnocreation.HoraFin,
                Recurso = recurso.Nombre,
            });
            if (turnoLibre.Count() > 0)
                throw new ArgumentException($"{recurso.Nombre} ya tiene un turno en ese horario");

            //check that the slot has not been blocked
            var bloqueos = await _manager.Bloqueo.GetFiltered(new BloqueoParameters
            {
                FechaDesde = turnoCompleto.Turnocreation.Fecha,
                FechaHasta = turnoCompleto.Turnocreation.Fecha,
                HoraInicio = turnoCompleto.Turnocreation.HoraInicio,
                HoraFin = turnoCompleto.Turnocreation.HoraFin,
                recursoId = recurso.RecursoId
            });
            if(bloqueos.Count() > 0)
                throw new ArgumentException($"{recurso.Nombre} no se encuentra disponible en este turno debido a {bloqueos.ElementAt(0).Motivo} ");

            Turno turno = _mapper.Map<Turno>(turnoCompleto.Turnocreation);

            var client = await _manager.Cliente.GetByIdAsync(turnoCompleto.Turnocreation.ClienteId);
            if (client == null)
            {
                await _validation.ValidateAsync(turnoCompleto.Clientecreation, createuserValidator);                   
                Cliente cliente = _mapper.Map<Cliente>(turnoCompleto.Clientecreation);
                turno.Cliente = cliente;
            }
            else
            {
                turno.ClienteId = client.ClienteId;

            }
           

            turno.Pagos.Add(_mapper.Map<Pago>(turnoCompleto.Pagocreation));                
            _manager.Turno.Add(turno);
            TurnoDto turnodto = _mapper.Map<TurnoDto>(turno);

            await _manager.UnitOfWork.SaveChangesAsync();

            return turnodto;

        }

        public async Task DeleteAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            var turno = await _manager.Turno.GetByIdAsync(Id);
            if (turno == null)
                throw new KeyNotFoundException("El turno no existe");

            _manager.Turno.Delete(turno);
            await _manager.UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<TurnoDto>> GetByWeek(DateOnly? date )
        {
            if (date <= DateOnly.MinValue)
                date = DateOnly.FromDateTime(DateTime.UtcNow);

            var startOfWeek = date.GetStartOfTheWeek();

            var turno = await _manager.Turno.GetByWeek((DateOnly)startOfWeek);

            List<TurnoDto> dto = _mapper.Map<List<TurnoDto>>(turno);

            return dto;

        }
        public async Task<IEnumerable<TurnoDto>> GetFiltered(TurnosParameters param)
        {
            var turnos = await _manager.Turno.GetFiltered(param);
            return _mapper.Map<IEnumerable<TurnoDto>>(turnos);
        }

        public async Task<TurnoDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            if (Id == Guid.Empty)
                throw new ArgumentNullException(nameof(Id));

            var turno = await _manager.Turno.GetByIdAsync(Id);

            if (turno == null)
                throw new KeyNotFoundException("El turno no existe");

            return _mapper.Map<TurnoDto>(turno);
        }

        public Task UpdateAsync(Guid Id, TurnoUpdateDto ownerForUpdateDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<TurnoDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new Exception("No se ha implementado el método GetAllAsync");
        }
    }
}
