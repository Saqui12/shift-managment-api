using Application.Services.DTOs.HorarioDisponibilidad;

namespace Application.Services.Iterfaces
{
    public interface IHorarioDisponibilidadService
    {
        Task<HorarioDisponibilidadDto> CreateAsync(HorarioDisponibilidadCreation disponible, CancellationToken cancellationToken = default);
        Task<HorarioDisponibilidadDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid Id, UpdateHorariosDisponibilidadDto Dto, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid Id, CancellationToken cancellationToken = default);
    }
}
