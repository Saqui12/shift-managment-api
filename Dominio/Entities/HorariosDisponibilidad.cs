using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class HorariosDisponibilidad
{
    public Guid HorariosDisponibilidadId { get; set; }

    public Guid RecursoId { get; set; }

    public string? DiaSemana { get; set; }

    public TimeOnly HoraApertura { get; set; }

    public TimeOnly HoraCierre { get; set; }

    public virtual Recurso Recurso { get; set; } = null!;
}
