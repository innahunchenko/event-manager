using EventManager.API.Database.Models;
using EventManager.API.Domain;
using EventManager.API.Mapping;
using EventManager.API.Repositories;

namespace EventManager.API.Services
{
    public class TopicService : IBaseService<Topic>
    {
        private readonly IBaseRepository<TopicEntity> repository;

        public TopicService(IBaseRepository<TopicEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<Guid> CreateAsync(Topic topic)
        {
            var entity = new TopicEntity();
            entity.From(topic);
            var id = await repository.CreateAsync(entity);
            return id;
        }

        public async Task CreateRangeAsync(IEnumerable<Topic> topics)
        {
            var entities = topics.ToEntities();
            await repository.CreateRangeAsync(entities);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await repository.GetByIdAsync(Guid.Parse(id));
            if (entity is null)
                return false;

            await repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<Topic>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            var topics = entities.ToDomains();
            return topics;
        }

        public async Task<Topic> GetByIdAsync(string id)
        {
            var entity = await repository.GetByIdAsync(Guid.Parse(id));
            var topic = new Topic();
            entity.From(topic);
            return topic;
        }

        public async Task<Topic> UpdateAsync(Topic topic)
        {
            var entity = await repository.GetByIdAsync(topic.Id);
            entity.From(topic);
            entity = await repository.UpdateAsync(entity);
            topic.From(entity);
            return topic;
        }
    }
}
