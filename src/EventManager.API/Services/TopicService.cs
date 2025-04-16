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
            var dbEntity = topic.ToEntity();
            dbEntity = await repository.CreateAsync(dbEntity);
            topic = dbEntity.ToDomain();
            return topic;
        }

        public async Task CreateRangeAsync(IEnumerable<Topic> topics)
        {
            var entities = topics.Select(u => u.ToEntity()).ToList();
            await repository.CreateRangeAsync(entities);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Topic>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            var events = entities.Select(u => u.ToDomain()).ToList();
            return events;
        }

        public async Task<Topic> GetByIdAsync(Guid id)
        {
            var entity = await repository.GetByIdAsync(id);
            var topic = entity.ToDomain();
            return topic;
        }

        public async Task UpdateAsync(Topic topic)
        {
            var entity = topic.ToEntity();
            await repository.UpdateAsync(entity);
        }
    }
}
