
using Application.Services.DTOs.Recurso;
using Dominio.Entities;

namespace Application.Services.DTOs.Turno
{
    public class TurnoDto : TurnoBaseDto
    {
        public Guid TurnoId { get; set; }
     
        public ClientedelTurnoDto Cliente { get; set; }

        public RecursoTurnoDto Recurso { get; set; }
    }
}
