using EventManager.API.Database.Models;
using System.Linq.Expressions;
namespace EventManager.API.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : DbBaseEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> CreateAsync(TEntity entity);
        Task CreateRangeAsync(IList<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] includes);
        Task DeleteAsync(TEntity entity);
    }
}
