using EventManager.API.Common;
using EventManager.API.Database.Models;
using EventManager.API.Domain;
using EventManager.API.Errors;
using EventManager.API.Mapping;
using EventManager.API.Repositories;
using EventManager.API.Requests;
using Microsoft.AspNetCore.JsonPatch;

namespace EventManager.API.Services
{
    public class TopicService : ITopicService
    {
        private readonly IBaseRepository<TopicEntity> repository;

        public TopicService(IBaseRepository<TopicEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<Result<Guid>> CreateAsync(Topic topic)
        {
            var entity = new TopicEntity();
            entity.From(topic);
            var id = await repository.CreateAsync(entity);
            return id;
        }

        public async Task<Result> DeleteAsync(string id)
        {
            var entity = await repository.GetByIdAsync(Guid.Parse(id));
            if (entity == null)
                return Result.Failure(DomainErrors.NotFound<Topic>(id));

            await repository.DeleteAsync(entity);
            return Result.Success();
        }

        public async Task<Result<List<Topic>>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            var events = entities.ToDomains();
            return events;
        }

        public async Task<Result<Topic>> GetByIdAsync(string id)
        {
            var entity = await repository.GetByIdAsync(Guid.Parse(id));

            if (entity == null)
                return Result.Failure<Topic>(DomainErrors.NotFound<Topic>(id));

            var topic = new Topic();
            topic.From(entity);
            return topic;
        }

        public async Task<Result<Topic>> UpdateAsync(string id, JsonPatchDocument<TopicRequest> patchDoc)
        {
            var entity = await repository.GetByIdAsync(Guid.Parse(id));
            if (entity == null)
                return Result.Failure<Topic>(DomainErrors.NotFound<Topic>(id));

            var request = new TopicRequest();
            request.From(entity);
            patchDoc.ApplyTo(request);
            entity.From(request);
            entity = await repository.UpdateAsync(entity);
            var topic = new Topic();
            topic.From(entity);
            return topic;
        }
    }
}
