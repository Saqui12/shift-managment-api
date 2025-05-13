using Application.Services.DTOs.Cliente;
using Dominio.Models.Parameters;

namespace Application.Services.Iterfaces
{
    public interface IClientesService
    {
        Task<IEnumerable<ClienteDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<ClienteFilteredDto>> GetAllFilterAsync(ClientesParameters param);
        Task<ClienteDto> CreateAsync(ClienteCreationDto turnoCompleto, CancellationToken cancellationToken = default);
        Task<ClienteDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid Id, ClienteDto Dto, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid Id, CancellationToken cancellationToken = default);
    }
}
