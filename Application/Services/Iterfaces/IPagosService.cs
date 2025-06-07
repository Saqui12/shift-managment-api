using Application.Services.DTOs.Pago;
using Dominio.Models.Parameters;


namespace Application.Services.Iterfaces
{
    public interface IPagosService
    {
        Task<PagedResults<PagoWithClient>> GetAllFilterAsync(PagosParameters param,CancellationToken cancellationToken = default);

        Task<PagoDto> CreateAsync(PagoCreationDto pagoAdd, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid Id, PagoUpdateDto Dto, CancellationToken cancellationToken = default);
        Task<PagoDto> GetByTurnoAsync(Guid id);

    }
}
