using EventManager.API.Database.Models;
using System.Linq.Expressions;
namespace EventManager.API.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : DbBaseEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<Guid> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] includes);
        Task DeleteAsync(TEntity entity);
    }
}
