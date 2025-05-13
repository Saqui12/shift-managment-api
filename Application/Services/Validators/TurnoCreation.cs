

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
            RuleFor(x => x.HoraInicio)
                .NotEmpty()
                .WithMessage("La hora de inicio debe ser mayor a las 8:00")
                .Must(x => x > TimeOnly.Parse("08:00"))
                .WithMessage("La hora debe ser mayor a la hora actual");
            RuleFor(x => x.Estado)
                .Matches(@"^(confirmado|completado|cancelado)$")
                .WithMessage("El estado debe ser uno de los siguientes : confirmado ; completado ; cancelado");
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
