
namespace Application.Services.DTOs.Pago
{
    public class PagoBaseDto
    {
        public decimal Monto { get; set; }

        public string MetodoPago { get; set; } = null!;

        public string? Estado { get; set; } = "pendiente";

        public string? TransaccionId { get; set; }
    }
}
