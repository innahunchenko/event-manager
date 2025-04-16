using EventManager.API.Database.Models;

namespace EventManager.API.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : DbBaseEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task CreateRangeAsync(IList<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}
