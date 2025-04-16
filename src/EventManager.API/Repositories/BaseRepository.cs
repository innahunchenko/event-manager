using EventManager.API.Database;
using EventManager.API.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.API.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : DbBaseEntity
    {
        private readonly AppDbContext context;

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

        public async Task UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
