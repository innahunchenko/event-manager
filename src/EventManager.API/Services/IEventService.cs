using EventManager.API.Domain;

namespace EventManager.API.Services
{
    public interface IEventService : IBaseService<Event>
    {
        //Task<Result<Event>> UpdateAsync(string id, JsonPatchDocument<EventRequest> patchDoc);
    }
}
