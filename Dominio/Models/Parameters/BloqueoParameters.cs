namespace Dominio.Models.Parameters
{
    public class BloqueoParameters : RequestParameters
    {
        public Guid recursoId { get; set; }
        public string motivo { get; set; } = string.Empty;
        public DateOnly Fecha { get; set; }
        public TimeOnly HoraInicio { get; set; } = TimeOnly.MinValue;
        public TimeOnly HoraFin { get; set; } = TimeOnly.MaxValue;
        public DateOnly FechaHasta { get; set; } = DateOnly.FromDateTime(DateTime.Now).AddMonths(12);
        public DateOnly FechaDesde { get; set; } = DateOnly.FromDateTime(DateTime.MinValue);
    }
}
