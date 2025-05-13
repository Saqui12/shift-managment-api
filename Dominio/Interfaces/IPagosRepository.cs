using Dominio.Entities;
using Dominio.Models.Parameters;


namespace Dominio.Interfaces
{
    public interface IPagosRepository: IBaseRepository<Pago>
    {
        Task <IEnumerable<Pago>> GetAllFilterAsync(PagosParameters param);
    }
}
