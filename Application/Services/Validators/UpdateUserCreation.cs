using Application.Services.DTOs.User;
using FluentValidation;

namespace Application.Services.Validators
{
    public class UpdateUserCreation: AbstractValidator<UpdateUser>
    {
        public UpdateUserCreation()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("El nombre completo es requerido")
                .MinimumLength(3)
                .WithMessage("El nombre completo debe tener al menos 3 caracteres");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("El correo electrónico es requerido")
                .EmailAddress()
                .WithMessage("El correo electrónico no es válido");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("El número de teléfono es requerido")
                .Matches(@"^\d{10}$")
                .WithMessage("El número de teléfono debe tener 10 dígitos");
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("El nombre de usuario es requerido")
                .MinimumLength(3)
                .WithMessage("El nombre de usuario debe tener al menos 3 caracteres");
        }
    }
}
