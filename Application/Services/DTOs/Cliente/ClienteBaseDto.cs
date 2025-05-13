

namespace Application.Services.DTOs.Cliente
{
    public class ClienteBaseDto
    {
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Telefono { get; set; }

        public bool? Activo { get; set; }
    }
}
