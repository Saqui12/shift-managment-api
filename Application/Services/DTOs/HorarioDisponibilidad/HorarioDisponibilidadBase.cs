namespace Application.Services.DTOs.HorarioDisponibilidad
{
    public class HorarioDisponibilidadBase
    {
        public Guid RecursoId { get; set; }

        public string? DiaSemana { get; set; }

        public TimeOnly HoraApertura { get; set; }

        public TimeOnly HoraCierre { get; set; }

    }
}
