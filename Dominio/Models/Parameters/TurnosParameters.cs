
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Models.Parameters
{
    [NotMapped]
    public class TurnosParameters : RequestParameters
    {
        public string? Estado { get; set; }
        public string? Recurso { get; set; }
        public string? ApellidoCliente { get; set; }
        public TimeOnly HoraInicio { get; set; } = TimeOnly.MinValue;
        public TimeOnly HoraFin { get; set; } = TimeOnly.MaxValue;
        public DateOnly FechaHasta { get; set; } = DateOnly.FromDateTime(DateTime.Now).AddMonths(12);
        public DateOnly FechaDesde { get; set; } = DateOnly.FromDateTime(DateTime.MinValue);

        public TurnosParameters()
        {
            OrderBy = "Fecha";
        }
    }
}
