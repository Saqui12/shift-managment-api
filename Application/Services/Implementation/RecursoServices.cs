using Application.Services.DTOs;
using Application.Services.DTOs.Recurso;
using Application.Services.Iterfaces;
using Dominio.Entities;
using Dominio.Interfaces;
using MapsterMapper;

namespace Application.Services.Implementation
{
    public class RecursoServices
        (IRecursoRepository _repo,
          IMapper mapper,
          IUnitOfWork unitOfWork) : IRecursoServices
    {
        public async Task<RecursoDto> AddRecurso(AddRecursoDto recurso)
        {
            //Add validation 

            if (recurso == null)
                throw new ArgumentNullException("values cannot be null");

            var _recurso = mapper.Map<Recurso>(recurso);
            _repo.Add(_recurso);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<RecursoDto>(_recurso);
        }
        public async Task<IEnumerable<Recurso>> GetRecursos()
        {
            var recursos = await _repo.GetAllAsync();

            return (recursos);
        }

        public async Task<ServiceResponse> DeleteRecurso(Guid recursoid)
        {
            var recurso = await _repo.GetByIdAsync(recursoid);
            if (recurso == null)
                return new ServiceResponse { Message = "Resource not found" };
            _repo.Delete(recurso);
            await unitOfWork.SaveChangesAsync();
            return new ServiceResponse { Message = "Resource deleted successfully" };
        }

        public async Task<ServiceResponse> UpdateRecurso(Guid recursoid, AddRecursoDto recurso)
        {
            var _recurso = await _repo.GetByIdAsync(recursoid);
            if (_recurso == null)
                return new ServiceResponse { Message = "Resource not found" };

            mapper.Map(recurso, _recurso);
            _repo.Update(_recurso);
            await unitOfWork.SaveChangesAsync();
            return new ServiceResponse { Message = "Resource updated successfully" };
        }
    }
}
