

using Application.Services.DTOs.Turno;
using FluentValidation;

namespace Application.Services.Validators
{
    public class UpdateTurno : AbstractValidator<TurnoUpdateDto>
    {
        public UpdateTurno() 
        {
            RuleFor(x => x.Turno.Fecha)
                .NotEmpty()
                .WithMessage("Date can't be empty");
            RuleFor(x => x.Turno.HoraFin)
                .NotEmpty()
                .WithMessage("End time must have a value")
                .Must((x, HoraFin) => HoraFin > x.Turno.HoraInicio)
                .WithMessage("End time must be higher than start time");
            RuleFor(x => x.Turno.HoraInicio)
                .NotEmpty()
                .WithMessage("Start time must have a value")
                .Must((x, HoraInicio) => HoraInicio < x.Turno.HoraFin)
                .WithMessage("Start time must be lower than end time");
            RuleFor(x => x.Turno.Estado)
                .Matches(@"^(pending|confirmed|completed|canceled)$")
                .WithMessage("Status must be one of the following : pending ; confirmed ; completed; canceled");
            RuleFor(x => x.Turno.MontoTotal)
                .NotEmpty()
                .WithMessage("Price must have value")
                .GreaterThan(0)
                .WithMessage("Price must be higher than 0");
            RuleFor(x => x.Turno.RecursoId)
                .NotEmpty()
                .WithMessage("A resource must be selected")
                .Must(x => x != Guid.Empty)
                .WithMessage("The resource must be a valid Guid");
            RuleFor(x => x.Turno.ClienteId)
                .NotEmpty()
                .WithMessage("Client must be selected")
                .Must(x => x != Guid.Empty)
                .WithMessage("Client Guid must be valid");

        }
    }
}
