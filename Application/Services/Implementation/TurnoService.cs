
using Application.Services.DTOs;
using Application.Services.DTOs.Cliente;
using Application.Services.DTOs.Pago;
using Application.Services.DTOs.Turno;
using Application.Services.Iterfaces;
using Application.Services.Validators;
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
IValidator<ClienteCreationDto> @object, IValidator<TurnoCreationDto> createTurnoValidator,
            IValidationService _validation) : ITurnoService
    {
        // Ask for clientid , if doesnt exist, creat one. If exist go on
        public async Task<TurnoDto> CreateAsync(TurnoCompletoDto turnoCompleto, CancellationToken cancellationToken = default)
        {

            //if (turnoCompleto.Pagocreation is null)
            //    throw new ArgumentException($"must insert the values of payment {turnoCompleto.Pagocreation}");

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
                throw new ArgumentException($"{recurso.Nombre} is not open to public on this date and time");

            var turnoLibre = await _manager.Turno.GetOverShift
                (turnoCompleto.Turnocreation.RecursoId, turnoCompleto.Turnocreation.Fecha, turnoCompleto.Turnocreation.HoraInicio, turnoCompleto.Turnocreation.HoraFin);
          
                if (turnoLibre.Count() > 0)
                throw new ArgumentException($"{recurso.Nombre} already has a shift at this time");

            //check that the slot has not been blocked
            var bloqueos = await _manager.Bloqueo.GetOverBloqueo(turnoCompleto.Turnocreation.RecursoId, turnoCompleto.Turnocreation.Fecha, turnoCompleto.Turnocreation.HoraInicio, turnoCompleto.Turnocreation.HoraFin);

            if (bloqueos.Count() > 0)
                throw new ArgumentException($"{recurso.Nombre} it is not available at this time due to {bloqueos.ElementAt(0).Motivo} ");

            Turno turno = _mapper.Map<Turno>(turnoCompleto.Turnocreation);

            var client = await _manager.Cliente.GetByIdAsync(turnoCompleto.Turnocreation.ClienteId);
            turno.ClienteId = client.ClienteId;


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

        public async Task<PagedResults<TurnoDto>> GetFiltered(TurnosParameters param)
        {
            var turnosPage = await _manager.Turno.GetFiltered(param);
            var _turnos = _mapper.Map<IEnumerable<TurnoDto>>(turnosPage.Items);
            var pagination = new PagedResults<TurnoDto>(_turnos, turnosPage.TotalCount, turnosPage.PageNumber, turnosPage.PageSize);
         

            return pagination;
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

        public async Task<ServiceResponse> UpdateAsync(Guid Id, TurnoUpdateDto turnoUpdate, CancellationToken cancellationToken = default)
        {
            if (Id == Guid.Empty)
                return new ServiceResponse { Message = "Id must be provided" };


            if (turnoUpdate.Pago == null && turnoUpdate.Turno == null)
                return new ServiceResponse { Message = "A Shift and payment must be provided" };

            await _validation.ValidateAsync(turnoUpdate.Turno, createTurnoValidator);
            await _validation.ValidateAsync(turnoUpdate.Pago!, createPago);


            //validate pago turno
            var turno = await _manager.Turno.GetByIdAsync(Id);
            if (turno == null)
                return new ServiceResponse { Message = "Turno not found" };

            var pago = await _manager.Pagos.GetByTurnoIdAsync(Id);
            if (pago == null)
                return new ServiceResponse { Message = "Pago not found" };

            turno = _mapper.Map(turnoUpdate.Turno, turno);
            _manager.Turno.Update(turno);
            pago = _mapper.Map(turnoUpdate.Pago, pago);
            _manager.Pagos.Update(pago);

            //check if the recurso is active
            var recurso = await _manager.Recurso.GetByIdAsync(turno.RecursoId);
            if (!recurso.Activo)
                throw new ArgumentException($"{recurso.Nombre} se encuentra fuera de servicio en el turno solicitado");

            //check if the recurso is available
            var dia = turno.Fecha.DayOfWeek;
            var recursoDisponible = await _manager.HorariosDisponibilidad.HorarioEstaDisponible(dia.ToString(), turno.HoraInicio, turno.HoraFin);
            if (!recursoDisponible)
                throw new ArgumentException($"El recurso {recurso.Nombre} no se encuentra abierto al publico en el horario o dia solicitado");

            //check there is no other shifts in the same time that are not the same shift
            var turnoLibre = await _manager.Turno.GetOverShift
                (turno.RecursoId, turno.Fecha, turno.HoraInicio, turno.HoraFin);

            if (turnoLibre.Count() > 0) {
                if (turnoLibre.FirstOrDefault()?.TurnoId != Id)
                    throw new ArgumentException($"{recurso.Nombre} it has already a shift in this slot");
            }

            //check that the slot has not been blocked
            var bloqueos = await _manager.Bloqueo.GetOverBloqueo(turno.RecursoId, turno.Fecha, turno.HoraInicio, turno.HoraFin);
            if (bloqueos.Count() > 0)
                throw new ArgumentException($"{recurso.Nombre} it's not available at this time because of {bloqueos.ElementAt(0).Motivo} ");


             await _manager.UnitOfWork.SaveChangesAsync();
            return new ServiceResponse { Message = "Turno updated successfully" ,Success=true};


        }
        public Task<IEnumerable<TurnoDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new Exception("No se ha implementado el método GetAllAsync");
        }
    }
}
