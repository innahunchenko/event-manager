using EventManager.API.Database.Models;

namespace EventManager.API.Repositories
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task AssignEventsToUserAsync(UserEntity user);
        Task<List<EventEntity>> GetUserEventsAsync(List<Guid> eventIds);
    }
}
