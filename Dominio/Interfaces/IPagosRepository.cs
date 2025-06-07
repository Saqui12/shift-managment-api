using Dominio.Entities;
using Dominio.Models.Parameters;


namespace Dominio.Interfaces
{
    public interface IPagosRepository: IBaseRepository<Pago>
    {
        Task <PagedResults<Pago>> GetAllFilterAsync(PagosParameters param);
        Task<Pago?> GetByTurnoIdAsync(Guid id);
    }
}
