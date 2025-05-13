using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class Bloqueo
{
    public Guid BloqueoId { get; set; }

    public Guid RecursoId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public string? Motivo { get; set; }

    public virtual Recurso Recurso { get; set; } = null!;
}
