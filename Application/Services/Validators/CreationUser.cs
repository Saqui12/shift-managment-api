using Application.Services.DTOs.User;
using FluentValidation;

namespace Application.Services.Validators
{
    public class CreationUser : AbstractValidator<CreateUser>
    {
        public CreationUser() 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("El email no puede estar vacio")
                .EmailAddress()
                .WithMessage("El email no es valido");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("La contraseña no puede estar vacia")
                .MinimumLength(8)
                .WithMessage("La contraseña debe tener al menos 8 caracteres")
                .Matches("([A-Za-z\\d$@$!%*?&]|[^ ]){8,15}")
                .WithMessage("La contraseña debe contener al menos una letra mayuscula, una letra minuscula, un numero y un caracter especial");
           
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("La confirmacion de la contraseña no puede estar vacia")
                .Equal(x => x.Password)
                .WithMessage("La confirmacion de la contraseña no coincide con la contraseña");
        }
    }
}
