using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class Turno
{
    public Guid TurnoId { get; set; }

    public Guid ClienteId { get; set; }

    public Guid RecursoId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public string? Estado { get; set; }

    public decimal MontoTotal { get; set; }

    public DateTime? FechaReserva { get; set; } = null!;

    public string? Notas { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Recurso Recurso { get; set; } = null!;
}
