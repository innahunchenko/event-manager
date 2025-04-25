using EventManager.API.Common;
using EventManager.API.Database.Models;

namespace EventManager.API.Repositories
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<bool> AssignEventsToUserAsync(UserEntity user);
        Task<List<EventEntity>> GetUserEventsAsync(List<Guid> eventIds);
    }
}
