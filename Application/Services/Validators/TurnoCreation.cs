﻿

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
                .WithMessage("Date can't be empty")
                .Must(x => x > DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("Date must be higher than current date");
            RuleFor(x=>x.HoraFin)
                .NotEmpty()
                .WithMessage("End time must have a value")
                .Must((x, HoraFin) => HoraFin > x.HoraInicio)
                .WithMessage("End time must be higher than start time");
            RuleFor(x=>x.HoraInicio)
                .NotEmpty()
                .WithMessage("Start time must have a value")
                .Must((x, HoraInicio) => HoraInicio < x.HoraFin)
                .WithMessage("Start time must be lower than end time");
            RuleFor(x => x.Estado)
                .Matches(@"^(pending|confirmed|completed|canceled)$")
                .WithMessage("Status must be one of the following : pending ; confirmed ; completed; canceled");
            RuleFor(x => x.MontoTotal)
                .NotEmpty()
                .WithMessage("Price must have value")
                .GreaterThan(0)
                .WithMessage("Price must be higher than 0");
            RuleFor(x => x.RecursoId)
                .NotEmpty()
                .WithMessage("A resource must be selected")
                .Must(x => x != Guid.Empty)
                .WithMessage("The resource must be a valid Guid");
            RuleFor(x => x.ClienteId)
                .NotEmpty()
                .WithMessage("Client must be selected")
                .Must(x => x != Guid.Empty)
                .WithMessage("Client Guid must be valid");
        }
    }
    
    
}
