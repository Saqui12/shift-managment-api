using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class Pago
{
    public Guid PagoId { get; set; }

    public Guid TurnoId { get; set; }

    public decimal Monto { get; set; }

    public string MetodoPago { get; set; } = null!;

    public DateTime? FechaPago { get; set; } = null!;

    public string? Estado { get; set; }

    public string? TransaccionId { get; set; }

    public virtual Turno Turno { get; set; } = null!;
}
