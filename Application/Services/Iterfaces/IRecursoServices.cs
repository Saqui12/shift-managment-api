using Application.Services.DTOs.Recurso;
using Application.Services.DTOs;
using Dominio.Entities;

namespace Application.Services.Iterfaces
{
    public interface IRecursoServices
    {
        Task<RecursoDto> AddRecurso(AddRecursoDto recurso);
        Task<IEnumerable<Recurso>> GetRecursos();
        Task<ServiceResponse> DeleteRecurso(Guid recursoid);
        Task<ServiceResponse> UpdateRecurso(Guid recursoid, AddRecursoDto recurso);



    }
}
