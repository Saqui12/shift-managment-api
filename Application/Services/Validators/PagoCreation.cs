
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
                .Must(x => x == "efectivo" || x == "tarjeta" || x == "mercadopago" || x == "cuentadni" || x == "transferencia")
                .WithMessage("El estado debe ser uno de los siguientes : efectivo ; tarjeta ; mercadopago ; cuentadni ; transferencia");
            RuleFor(x => x.Estado)
                .Must(x => x == "pendiente" || x == "completado" || x == "cancelado")
                .WithMessage("El estado debe ser uno de los siguientes : pendiente ; completado ; cancelado");
        }
    }
}
