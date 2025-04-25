using EventManager.API.Common;
using EventManager.API.Database.Models;

namespace EventManager.API.Repositories
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<Result> AssignEventsToUserAsync(UserEntity user);
        Task<Result<List<EventEntity>>> GetUserEventsAsync(List<Guid> eventIds);
    }
}
