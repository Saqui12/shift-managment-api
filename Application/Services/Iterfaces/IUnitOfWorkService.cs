
namespace Application.Services.Iterfaces
{
    public interface IUnitOfWorkService
    {
        Task<int> SaveChangesAsync();
    }
}
