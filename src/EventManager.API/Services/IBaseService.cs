using EventManager.API.Common;
using EventManager.API.Domain;

namespace EventManager.API.Services
{
    public interface IBaseService<TEntity> where TEntity : IEntity
    {
        Task<Result<TEntity>> GetByIdAsync(string id);
        Task<Result<List<TEntity>>> GetAllAsync();
        Task<Result<Guid>> CreateAsync(TEntity entity);
        Task<Result<TEntity>> UpdateAsync(string id, TEntity entity);
        Task<Result> DeleteAsync(string id);
    }
}
