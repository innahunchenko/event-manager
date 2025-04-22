using EventManager.API.Domain;

namespace EventManager.API.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task AssignEventsToUserAsync(string userId, IEnumerable<string> eventIds);
        Task<List<Event>> GetUserEventsAsync(string userId);
    }
}
