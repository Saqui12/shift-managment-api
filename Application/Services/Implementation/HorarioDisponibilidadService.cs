using Application.Services.DTOs.HorarioDisponibilidad;
using Application.Services.Iterfaces;
using Dominio.Entities;
using Dominio.Interfaces;
using MapsterMapper;

namespace Application.Services.Implementation
{
    public class HorarioDisponibilidadService(IHorariosDisponibilidadRepository _respo,IMapper _mapper, IUnitOfWork _unit) : IHorarioDisponibilidadService
    {
        public async Task<HorarioDisponibilidadDto> CreateAsync(HorarioDisponibilidadCreation disponible, CancellationToken cancellationToken = default)
        {
            if (disponible is null)
                throw new ArgumentNullException("Values for availability must be given");

            //validation
            var horario=  _mapper.Map<HorariosDisponibilidad>(disponible);

            _respo.Add(horario);
            await _unit.SaveChangesAsync();
            var horarioDto = _mapper.Map<HorarioDisponibilidadDto>(horario);

            return horarioDto;

        }   

        public async Task DeleteAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            if (Id == Guid.Empty)
                throw new ArgumentNullException("Id is required");
            var horario = _respo.GetByIdAsync(Id);
            if (horario is null)
                throw new KeyNotFoundException("Availability not found");
            _respo.Delete(horario.Result);
            await _unit.SaveChangesAsync();

        }

        public Task<HorarioDisponibilidadDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Guid Id, UpdateHorariosDisponibilidadDto Dto, CancellationToken cancellationToken = default)
        {
            if (Id == Guid.Empty)
                throw new ArgumentNullException("Id is required");
            if (Dto is null)
                throw new ArgumentNullException("Values for availability must be given");
           
            var horario = _respo.GetByIdAsync(Id);
            
            if (horario is null)
                throw new KeyNotFoundException("Availability not found");
           
            var horarioUpdate = _mapper.Map<HorariosDisponibilidad>(Dto);
            horarioUpdate.HorariosDisponibilidadId = Id;
            _respo.Update(horarioUpdate);
            await _unit.SaveChangesAsync();

        }
    }
}
