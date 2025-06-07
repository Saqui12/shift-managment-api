
using Application.Services.DTOs.Pago;
using FluentValidation;

namespace Application.Services.Validators
{
    public class PagoCreation : AbstractValidator<PagoCreationDto>
    {
        public PagoCreation() 
        {
            RuleFor(x => x.Monto)
                .NotEmpty()
                .WithMessage("El monto no puede estar vacio")
                .GreaterThan(0)
                .WithMessage("El monto debe ser mayor a 0");

            RuleFor(x => x.MetodoPago)
                .NotEmpty()
                .WithMessage("El metodo de pago no puede estar vacio")
                .Must(x => x == "cash" || x == "credit-card" || x == "mercadopago" || x == "on-delivery" || x == "transfer")
                .WithMessage("El metodo de pago debe ser uno de los siguientes : cash ; credit-card ; mercadopago ; on-delivery ; transfer");
            RuleFor(x => x.Estado)
                .Must(x => x == "pending" || x == "completed" || x == "canceled")
                .WithMessage("El estado de pago debe ser uno de los siguientes : pending ; completed ; canceled");
        }
    }
}
