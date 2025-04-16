using EventManager.API.Domain;

namespace EventManager.API.Services
{
    public interface IBaseService<TEntity> where TEntity : DomainBaseEntity
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}
