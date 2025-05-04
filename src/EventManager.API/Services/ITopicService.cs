using EventManager.API.Domain;

namespace EventManager.API.Services
{
    public interface ITopicService : IBaseService<Topic>
    {
      //  Task<Result<Topic>> UpdateAsync(string id, JsonPatchDocument<TopicRequest> patchDoc);
    }
}
