using EventManager.API.Database.Configurations;
using EventManager.API.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.API.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<EventEntity> Events => Set<EventEntity>();
        public DbSet<TopicEntity> Topics => Set<TopicEntity>();
        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<UserEventEntity> UserEvents => Set<UserEventEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());
            modelBuilder.ApplyConfiguration(new UserEventConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
