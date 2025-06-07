
using Application.Services.DTOs.Pago;
using System.ComponentModel.DataAnnotations;

namespace Application.Services.DTOs.Turno
{
     public class TurnoUpdateDto
    {
        public TurnoCreationDto Turno { get; set; }=null!;
        public PagoCreationDto Pago { get; set; } = null!;
    }
}
