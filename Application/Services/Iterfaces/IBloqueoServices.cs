

using Application.Services.DTOs;
using Application.Services.DTOs.Bloqueo;
using Dominio.Entities;

namespace Application.Services.Iterfaces
{
    public interface IBloqueoServices
    {
        Task<BloqueoDto> AddBloqueo(AddBloqueoDto bloqueos);
        Task<IEnumerable<Bloqueo>> GetBloqueos();
        Task<ServiceResponse> DeleteBloqueo(Guid bloqueoid);
        Task<ServiceResponse> UpdateBloqueo(Guid bloqueoid, AddBloqueoDto bloqueos);
    }
}
