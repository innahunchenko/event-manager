using EventManager.API.Database;
using EventManager.API.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.API.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        { }

        public async Task<bool> AssignEventsToUserAsync(UserEntity user)
        {
            await context.UserEvents
                .Where(ue => ue.UserId == user.Id)
                .ExecuteDeleteAsync();

            foreach (var ue in user.UserEvents)
            {
                ue.Id = Guid.NewGuid();
                context.UserEvents.Add(ue);
            }

            var changes = await context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<List<EventEntity>> GetUserEventsAsync(List<Guid> eventIds)
        {
            var events = await context.Events
                .Where(x => eventIds.Contains(x.Id))
                .Include(x => x.Speaker)
                .Include(x => x.Topic)
                .ToListAsync();

            return events;
        }
    }
}
