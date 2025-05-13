
using System.ComponentModel.DataAnnotations;

namespace Application.Services.DTOs.Turno
{
    public class TurnoBaseDto
    {
        public Guid ClienteId { get; set; }

        public Guid RecursoId { get; set; }

        public DateOnly Fecha { get; set; }

        public TimeOnly HoraInicio { get; set; }

        public TimeOnly HoraFin { get; set; }

        public string? Estado { get; set; } = "confirmado";
      
        public decimal MontoTotal { get; set; }

        public string? Notas { get; set; }
    }
}
