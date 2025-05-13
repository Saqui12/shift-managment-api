namespace Application.Services.DTOs.Bloqueo
{
    public class BloqueoDto
    {
        public Guid BloqueoId { get; set; }

        public Guid RecursoId { get; set; }

        public DateOnly Fecha { get; set; }

        public TimeOnly HoraInicio { get; set; }

        public TimeOnly HoraFin { get; set; }

        public string? Motivo { get; set; }
    }
}
