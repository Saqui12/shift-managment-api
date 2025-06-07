

using Application.Services.DTOs;
using Application.Services.DTOs.Bloqueo;
using Application.Services.Iterfaces;
using Dominio.Entities;
using Dominio.Interfaces;
using Dominio.Models.Parameters;
using MapsterMapper;

namespace Application.Services.Implementation
{
    public class BloqueoService(IUnitOfWork UnitOfWork, IBloqueoRepository _repo,ITurnosRepository _turnos, IMapper mapper) : IBloqueoServices
    {

        public async Task<BloqueoDto> AddBloqueo(AddBloqueoDto bloqueo)
        {
            if (bloqueo == null)
                throw new ArgumentException("values cannot be null");

            var turnoLibre = await   _turnos.GetOverShift(bloqueo.RecursoId, bloqueo.Fecha, bloqueo.HoraInicio, bloqueo.HoraFin);

            if (turnoLibre.Count() > 0)
                throw new ArgumentException($" The venue has a shift at the time selected");

            //check that the slot has not been blocked
            var bloqueos = await _repo.GetOverBloqueo(bloqueo.RecursoId, bloqueo.Fecha, bloqueo.HoraInicio, bloqueo.HoraFin);

            if (bloqueos.Count() > 0)
                throw new ArgumentException($" The venue already has a blocking at the time selected : {bloqueos.ElementAt(0).Motivo} ");


            var _bloqueo = mapper.Map<Bloqueo>(bloqueo);
            _repo.Add(_bloqueo);
            await UnitOfWork.SaveChangesAsync();
            return mapper.Map<BloqueoDto>(_bloqueo);
        }
        public async Task<IEnumerable<Bloqueo>> GetBloqueos()
        {
            var bloqueos = await _repo.GetAllAsync();
            return (bloqueos);
        }
        public async Task<PagedResults<Bloqueo>> GetFilteredBloqueos(BloqueoParameters param)
        {
            var bloqueos = await _repo.GetFiltered(param);

            return new PagedResults<Bloqueo>(bloqueos.Items,bloqueos.TotalCount,bloqueos.PageNumber,bloqueos.PageSize);
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
        public async Task<ServiceResponse> UpdateBloqueo(Guid bloqueoid, AddBloqueoDto bloqueo)
        {
            if (Guid.Empty==bloqueoid)
            {
                throw new ArgumentException("Id cannot be null");
            }
            var recurso = await _repo.GetByIdAsync(bloqueoid);
            if (recurso == null)
                throw new ArgumentException($"Resource not found" );
            
            var turnoLibre = await _turnos.GetOverShift(bloqueo.RecursoId, bloqueo.Fecha, bloqueo.HoraInicio, bloqueo.HoraFin);
            if (turnoLibre.Count() > 0)
                throw new ArgumentException($" The venue has a shift at the time selected");

            //check that the slot has not been blocked
            var bloqueos = await _repo.GetOverBloqueo(bloqueo.RecursoId, bloqueo.Fecha, bloqueo.HoraInicio, bloqueo.HoraFin);

            if (bloqueos.Count() > 0)
            {
                if (bloqueos.FirstOrDefault()?.BloqueoId != bloqueoid)
                    throw new ArgumentException($" The venue already has a blocking at the time selected : {bloqueos.ElementAt(0).Motivo} ");
            }


            mapper.Map(bloqueo, recurso);
            _repo.Update(recurso);
            await UnitOfWork.SaveChangesAsync();
            return new ServiceResponse { Message = "Blocking slot updated successfully" };
        }
    }
}
