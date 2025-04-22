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

        public async Task<Topic> CreateAsync(Topic topic)
        {
            var entity = new TopicEntity();
            topic.ToEntity(entity);
            entity = await repository.CreateAsync(entity);
            entity.ToDomain(topic);
            return topic;
        }

        public async Task CreateRangeAsync(IEnumerable<Topic> topics)
        {
            var entities = topics.ToEntities();
            await repository.CreateRangeAsync(entities);
        }

        public async Task DeleteAsync(Topic topic)
        {
            var entity = new TopicEntity();
            topic.ToEntity(entity);
            await repository.DeleteAsync(entity);
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
            entity.ToDomain(topic);
            return topic;
        }

        public async Task<Topic> UpdateAsync(Topic topic)
        {
            var entity = await repository.GetByIdAsync(topic.Id);
            topic.ToEntity(entity);
            entity = await repository.UpdateAsync(entity);
            entity.ToDomain(topic);
            return topic;
        }
    }
}
