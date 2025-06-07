

using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Models.Parameters
{
    [NotMapped]
    public class PagosParameters : RequestParameters
    {
        public string? Estado { get; set; }
        public string? MetodoPago { get; set; }
        public DateTime FechaHasta { get; set; } = DateTime.UtcNow.AddYears(1000);
        public DateTime FechaDesde { get; set; } = DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc);
        public int MontoDesde { get; set; } = 0;
        public int MontoHasta { get; set; } = int.MaxValue;

        public string? NombreApellidoCliente { get; set; }

        public PagosParameters()
        {
            OrderBy = "Fecha";
        }

    }
}
