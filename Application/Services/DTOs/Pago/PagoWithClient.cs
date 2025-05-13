using Application.Services.DTOs.Turno;


namespace Application.Services.DTOs.Pago
{
    public class PagoWithClient : PagoBaseDto
    {
        public Guid TurnoId { get; set; }
        public byte[] FechaPago { get; set; } 
        public string? TransaccionId { get; set; }

        public TurnoPago Turno { get; set; } 
    }
    public class  TurnoPago
    {
        public string? Estado { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }

        public ClientedelTurnoDto Cliente { get; set; }

    }
}
