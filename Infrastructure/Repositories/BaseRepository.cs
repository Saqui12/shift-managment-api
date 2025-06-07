using Dominio.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly PeloterosDbContext _context;

        public BaseRepository(PeloterosDbContext context)
        {
            _context = context;
        }


        public async virtual Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().AsNoTracking().ToListAsync();
        public async Task<T> GetByIdAsync(Guid id) => await _context.Set<T>().FindAsync(id);
        public void Add(T entity) =>  _context.Set<T>().Add(entity);

        public void Update(T entity) =>  _context.Set<T>().Update(entity);
      
        public void Delete(T entity) =>  _context.Set<T>().Remove(entity);




    }

}
