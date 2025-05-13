namespace Application.Services.DTOs.Recurso
{
    public class AddRecursoDto
    {
        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public int? Capacidad { get; set; }

        public decimal PrecioHora { get; set; }

        public bool Activo { get; set; }
    }
}
