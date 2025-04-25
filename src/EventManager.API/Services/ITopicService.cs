using EventManager.API.Common;
using EventManager.API.Domain;
using EventManager.API.Requests;
using Microsoft.AspNetCore.JsonPatch;

namespace EventManager.API.Services
{
    public interface ITopicService : IBaseService<Topic>
    {
        Task<Result<Topic>> UpdateAsync(string id, JsonPatchDocument<TopicRequest> patchDoc);
    }
}
