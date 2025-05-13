﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Models.Parameters
{
    [NotMapped]
    public class ClientesParameters : RequestParameters 
    {
        public Guid? ClienteId { get; set; }

        public string? Nombre { get; set; } 

        public string? Apellido { get; set; } 

        public string? Email { get; set; } 

        public string? Telefono { get; set; }

        public DateOnly FechaRegistroHasta { get; set; } = DateOnly.FromDateTime(DateTime.MaxValue);

        public DateOnly FechaRegistroDesde { get; set; } = DateOnly.FromDateTime(DateTime.MinValue);
    }
}
