using EventManager.API.Domain;

namespace EventManager.API.Services
{
    public interface IBaseService<TEntity> where TEntity : IEntity
    {
        Task<TEntity> GetByIdAsync(string id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
