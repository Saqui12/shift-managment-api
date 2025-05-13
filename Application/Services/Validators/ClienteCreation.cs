
using Application.Services.DTOs.Cliente;
using FluentValidation;

namespace Application.Services.Validators
{
    public class ClienteCreation : AbstractValidator<ClienteCreationDto>
    {
        public ClienteCreation()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .WithMessage("El nombre no puede estar vacio")
                .MinimumLength(3)
                .WithMessage("El nombre debe tener al menos 3 caracteres");
            RuleFor(x => x.Apellido)
                .NotEmpty()
                .WithMessage("El apellido no puede estar vacio")
                .MinimumLength(3)
                .WithMessage("El apellido debe tener al menos 3 caracteres");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("El email no puede estar vacio")
                .EmailAddress()
                .WithMessage("El email no es valido");
            RuleFor(x => x.Telefono)
                .NotEmpty()
                .WithMessage("El telefono no puede estar vacio")
                .Matches(@"^\d{10}$")
                .WithMessage("El telefono debe tener 10 digitos");
            RuleFor(x => x.Activo)
                .NotNull()
                .WithMessage("El estado no puede estar vacio")
                .Must(x => x == true || x == false)
                .WithMessage("El estado debe ser verdadero o falso");
        }
    }
}
