using EventManager.API.Database;
using EventManager.API.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.API.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : DbBaseEntity
    {
        protected readonly AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task CreateRangeAsync(IList<TEntity> entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();

            if (entity is IHasNavigationLoad navEntity)
            {
                await navEntity.LoadNavigationsAsync(context);
                return entity;
            }

            var updated = await context.Set<TEntity>().FindAsync(entity.Id);
            return updated ?? throw new InvalidOperationException($"Entity of type {typeof(TEntity).Name} with ID '{entity.Id}' not found after update.");
        }

        public async Task DeleteAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
