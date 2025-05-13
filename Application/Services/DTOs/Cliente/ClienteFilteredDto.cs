using Application.Services.DTOs.Turno;

namespace Application.Services.DTOs.Cliente
{
    public class ClienteFilteredDto : ClienteDto
    {
        public List<TurnoBaseDto>? Turnos { get; set; } 
    }
}
