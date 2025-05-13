

namespace Dominio.Entities;

public partial class Recurso
{
    public Guid RecursoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? Capacidad { get; set; }

    public decimal PrecioHora { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Bloqueo> Bloqueos { get; set; } = new List<Bloqueo>();

    public virtual ICollection<HorariosDisponibilidad> HorariosDisponibilidads { get; set; } = new List<HorariosDisponibilidad>();

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
