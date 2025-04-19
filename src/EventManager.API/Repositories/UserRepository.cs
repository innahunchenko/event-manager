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
            await UpdateAsync(user);
        }
    }
}
