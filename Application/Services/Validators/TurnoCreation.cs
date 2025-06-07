

using Application.Services.DTOs.Turno;
using FluentValidation;

namespace Application.Services.Validators
{
    public class TurnoCreation : AbstractValidator<TurnoCreationDto>
    {
        public TurnoCreation()
        {
            RuleFor(x => x.Fecha)
                .NotEmpty()
                .WithMessage("La fecha no puede estar vacia")
                .Must(x => x > DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("La fecha debe ser mayor a la fecha actual");
            RuleFor(x=>x.HoraFin)
                .NotEmpty()
                .WithMessage("La hora de fin debe ser mayor a la hora de inicio")
                .Must((x, HoraFin) => HoraFin > x.HoraInicio)
                .WithMessage("La hora de fin debe ser mayor a la hora de inicio");
            RuleFor(x => x.Estado)
                .Matches(@"^(pending|confirmed|confirmed|canceled)$")
                .WithMessage("El estado debe ser uno de los siguientes : pending ; confirmed ; completed; canceled");
            RuleFor(x => x.MontoTotal)
                .NotEmpty()
                .WithMessage("El monto no puede estar vacio")
                .GreaterThan(0)
                .WithMessage("El monto debe ser mayor a 0");
            RuleFor(x => x.RecursoId)
                .NotEmpty()
                .WithMessage("El recurso no puede estar vacio")
                .Must(x => x != Guid.Empty)
                .WithMessage("El recurso no puede ser un guid vacio");
            RuleFor(x => x.ClienteId)
                .NotEmpty()
                .WithMessage("El cliente no puede estar vacio")
                .Must(x => x != Guid.Empty)
                .WithMessage("El cliente no puede ser un guid vacio");
        }
    }
    
    
}
