using Application.Services.DTOs.Cliente;
using Application.Services.DTOs.Pago;

namespace Application.Services.DTOs.Turno
{
    public class TurnoCompletoDto
    {
        public TurnoCreationDto Turnocreation { get; set; }
        public PagoCreationDto Pagocreation { get; set; }
    }
}
