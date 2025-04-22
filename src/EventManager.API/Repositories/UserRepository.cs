using EventManager.API.Database;
using EventManager.API.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.API.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        { }

        public async Task AssignEventsToUserAsync(UserEntity user)
        {
            var userEvents = await context.UserEvents.Where(x => x.UserId == user.Id).ToListAsync();
            context.UserEvents.RemoveRange(userEvents);
            await UpdateAsync(user, u => u.UserEvents);
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
