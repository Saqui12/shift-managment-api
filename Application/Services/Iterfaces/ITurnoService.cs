using Application.Services.DTOs;
using Application.Services.DTOs.Turno;
using Dominio.Models.Parameters;

namespace Application.Services.Iterfaces
{
    public interface ITurnoService
    {

        Task<IEnumerable<TurnoDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<PagedResults<TurnoDto>> GetFiltered(TurnosParameters param);
        Task<TurnoDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
        Task<TurnoDto> CreateAsync(TurnoCompletoDto turnoCompleto, CancellationToken cancellationToken = default);
        Task<ServiceResponse> UpdateAsync(Guid Id, TurnoUpdateDto Dto, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid Id, CancellationToken cancellationToken = default);



    }
}
