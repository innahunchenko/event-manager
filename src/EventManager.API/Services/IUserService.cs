using EventManager.API.Common;
using EventManager.API.Domain;

namespace EventManager.API.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<Result> AssignEventsToUserAsync(string userId, IEnumerable<string> eventIds);
        Task<Result<List<Event>>> GetUserEventsAsync(string userId);
    }
}
