using EventManager.API.Common;
using EventManager.API.Domain;
using EventManager.API.Requests;
using Microsoft.AspNetCore.JsonPatch;

namespace EventManager.API.Services
{
    public interface IEventService : IBaseService<Event>
    {
        Task<Result<Event>> UpdateAsync(string id, JsonPatchDocument<EventRequest> patchDoc);
    }
}
