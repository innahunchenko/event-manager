using EventManager.API.Common;
using EventManager.API.Domain;
using EventManager.API.Requests;
using Microsoft.AspNetCore.JsonPatch;

namespace EventManager.API.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<Result> AssignEventsToUserAsync(string userId, IEnumerable<string> eventIds);
        Task<Result<List<Event>>> GetUserEventsAsync(string userId);
        Task<Result<User>> UpdateAsync(string id, JsonPatchDocument<UserRequest> patchDoc);
    }
}
