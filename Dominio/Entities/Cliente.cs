

namespace Dominio.Entities;

public partial class Cliente
{
    public Guid ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateOnly FechaRegistro { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public bool? Activo { get; set; }

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
