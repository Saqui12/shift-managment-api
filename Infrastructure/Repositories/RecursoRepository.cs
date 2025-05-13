
using Dominio.Entities;
using Dominio.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class RecursoRepository : BaseRepository<Recurso>, IRecursoRepository
    {
        public RecursoRepository(PeloterosDbContext context)
            : base(context)
        {
        }
    }
    
    
}
