
using Application.Services.DTOs.Cliente;
using Application.Services.DTOs.Pago;
using Application.Services.DTOs.Turno;

namespace Application.Services.DTOs
{
    public class TurnoCompletoDto
    {
        public TurnoCreationDto Turnocreation { get; set; }
        public ClienteCreationDto Clientecreation { get; set; }
        public PagoCreationDto Pagocreation { get; set; }
    }
}
