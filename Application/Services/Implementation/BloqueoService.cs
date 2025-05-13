

using Application.Services.DTOs;
using Application.Services.DTOs.Bloqueo;
using Application.Services.Iterfaces;
using Dominio.Entities;
using Dominio.Interfaces;
using MapsterMapper;

namespace Application.Services.Implementation
{
    public class BloqueoService(IUnitOfWork UnitOfWork, IBloqueoRepository _repo, IMapper mapper) : IBloqueoServices
    {

        public async Task<BloqueoDto> AddBloqueo(AddBloqueoDto bloqueos)
        {
            if (bloqueos == null)
                throw new ArgumentNullException("Bloqueo cannot be null");
            var _bloqueo = mapper.Map<Bloqueo>(bloqueos);
            _repo.Add(_bloqueo);
            await UnitOfWork.SaveChangesAsync();
            return mapper.Map<BloqueoDto>(_bloqueo);
        }
        public async Task<IEnumerable<Bloqueo>> GetBloqueos()
        {
            var bloqueos = await _repo.GetAllAsync();
            return (bloqueos);
        }
        public async Task<ServiceResponse> DeleteBloqueo(Guid bloqueoid)
        {
            var recurso = await _repo.GetByIdAsync(bloqueoid);
            if (recurso == null)
                return new ServiceResponse { Message = "Recurso not found" };
            _repo.Delete(recurso);
            await UnitOfWork.SaveChangesAsync();
            return new ServiceResponse { Message = "Recurso deleted successfully" };
        }
        public async Task<ServiceResponse> UpdateBloqueo(Guid bloqueoid, AddBloqueoDto bloqueos)
        {
            var recurso = await _repo.GetByIdAsync(bloqueoid);
            if (recurso == null)
                return new ServiceResponse { Message = "Recurso not found" };
            mapper.Map(bloqueos, recurso);
            _repo.Update(recurso);
            await UnitOfWork.SaveChangesAsync();
            return new ServiceResponse { Message = "Recurso updated successfully" };
        }
    }
}
