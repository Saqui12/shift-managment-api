using Application.Services.DTOs.Cliente;
using Application.Services.Iterfaces;
using Application.Services.Validators.Iterface;
using Dominio.Entities;
using Dominio.Interfaces;
using Dominio.Models.Parameters;
using FluentValidation;
using MapsterMapper;


namespace Application.Services.Implementation
{
    public class ClienteService(IClienteRepository _repo,IValidator<ClienteCreationDto> createuserValidator,
        IValidationService _validation,IUnitOfWork _unit,IMapper _mapper) : IClientesService
    {
        public async Task<ClienteDto> CreateAsync(ClienteCreationDto clienteAdd, CancellationToken cancellationToken = default)
        {

            await _validation.ValidateAsync(clienteAdd, createuserValidator);

            var cliente = _mapper.Map<Cliente>(clienteAdd);
            _repo.Add(cliente);
            await _unit.SaveChangesAsync();            
            return _mapper.Map<ClienteDto>(cliente);
        }
        public async Task<ClienteDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            var cliente = await _repo.GetByIdAsync(Id);
            if (cliente is null)
                throw new KeyNotFoundException("El cliente no existe");
            return _mapper.Map<ClienteDto>(cliente);
        }

        public async Task DeleteAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            var cliente = await _repo.GetByIdAsync(Id);
            if (cliente is null)
                throw new KeyNotFoundException("El cliente no existe");
            _repo.Delete(cliente);
            await _unit.SaveChangesAsync();

        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _mapper.Map<IEnumerable<ClienteDto>>( await _repo.GetAllAsync() ) ;
            
        }
        public async Task<IEnumerable<ClienteFilteredDto>> GetAllFilterAsync(ClientesParameters param)
        {
            var query = await _repo.GetAllFilterAsync(param);
            return _mapper.Map<IEnumerable<ClienteFilteredDto>>(query);
        }

        public async Task UpdateAsync(Guid Id, ClienteDto Dto, CancellationToken cancellationToken = default)
        {
            var cliente = await _repo.GetByIdAsync(Id);
            if (cliente is null)
                throw new KeyNotFoundException("El cliente no existe");
            if (Id != cliente.ClienteId)
                throw new ArgumentException("El id no coincide con el cliente a modificar");

            _repo.Update(_mapper.Map<Cliente>(Dto));
            await _unit.SaveChangesAsync();

        }
    }
}
