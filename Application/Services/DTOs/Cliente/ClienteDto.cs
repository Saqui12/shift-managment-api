
namespace Application.Services.DTOs.Cliente
{
    public class ClienteDto : ClienteBaseDto
    {
        public Guid ClienteId { get; set; }

        public DateOnly FechaRegistro { get; set; }
    }
}
