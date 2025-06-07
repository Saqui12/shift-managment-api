using Application.Services.DTOs;
using Application.Services.DTOs.Cliente;
using Application.Services.DTOs.Pago;
using Application.Services.Iterfaces;
using Application.Services.Validators.Iterface;
using Dominio.Entities;
using Dominio.Interfaces;
using Dominio.Models.Parameters;
using FluentValidation;
using MapsterMapper;



namespace Application.Services.Implementation
{
    public class PagoService(IPagosRepository _repo,IUnitOfWork _unit, IMapper _mapper
        ,IValidationService _validator, IValidator<PagoCreationDto> pagoCreation ) : IPagosService
    {
        public async Task<PagoDto> GetByTurnoAsync(Guid id)
        {
            var pago = await _repo.GetByTurnoIdAsync(id);
            if (pago is null)
                throw new KeyNotFoundException("Payment not found");
            return _mapper.Map<PagoDto>(pago);
        }
            

        public async Task<PagedResults<PagoWithClient>> GetAllFilterAsync(PagosParameters param,CancellationToken cancellationToken = default)
        {
            var lista = await _repo.GetAllFilterAsync(param);
            var listaPagos = _mapper.Map<IEnumerable<PagoWithClient>>(lista.Items);

            return new PagedResults<PagoWithClient>(listaPagos, lista.TotalCount, lista.PageNumber, lista.PageSize);

        }
        public async Task<PagoDto> CreateAsync(PagoCreationDto pagoAdd, CancellationToken cancellationToken = default)
        {
            await _validator.ValidateAsync(pagoAdd, pagoCreation);

            if (pagoAdd is null)
                throw new ArgumentNullException("No se ingreso un nuevo Pago");
            var pago = _mapper.Map<Pago>(pagoAdd);
            _repo.Add(pago);
            await _unit.SaveChangesAsync();
            return _mapper.Map<PagoDto>(pago);
        }

        public async Task UpdateAsync(Guid Id, PagoUpdateDto Dto, CancellationToken cancellationToken = default)
        {
            var pago = await _repo.GetByIdAsync(Id);
            if (pago is null)
                throw new KeyNotFoundException("Payment not found");
            if (Id != pago.PagoId)
                throw new ArgumentException("id does not match with the payment");
           var _pago = _mapper.Map(Dto,pago);
  
            _repo.Update(_pago);

            await _unit.SaveChangesAsync();

        }

    }
}
