

using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Models.Parameters
{
    [NotMapped]
    public class PagosParameters : RequestParameters
    {
        public string? Estado { get; set; }
        public string? MetodoPago { get; set; }       
        public DateOnly FechaHasta { get; set; } = DateOnly.FromDateTime(DateTime.Now).AddMonths(12);
        public DateOnly FechaDesde { get; set; } = DateOnly.FromDateTime(DateTime.MinValue);

        public string? ApellidoCliente { get; set; }

        public PagosParameters()
        {
            OrderBy = "Fecha";
        }

    }
}
