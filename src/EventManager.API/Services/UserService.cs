using EventManager.API.Database.Models;
using EventManager.API.Domain;
using EventManager.API.Mapping;
using EventManager.API.Repositories;

namespace EventManager.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var userEntity = await repository.GetByIdAsync(Guid.Parse(id));
            var user = userEntity.ToUser();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var userEntities = await repository.GetAllAsync();
            var users = userEntities.Select(u => u.ToUser()).ToList();
            return users;
        }

        public async Task<User> CreateAsync(User user)
        {
            var userEntity = user.ToDbEntity();
            userEntity = await repository.CreateAsync(userEntity);
            user = userEntity.ToUser();
            return user;
        }

        public async Task CreateRangeAsync(IEnumerable<User> users)
        {
            var entities = users.Select(u => u.ToDbEntity()).ToList();
            await repository.CreateRangeAsync(entities);
        }

        public async Task<User> UpdateAsync(User user)
        {
            var entity = user.ToDbEntity();
            entity = await repository.UpdateAsync(entity);
            user = entity.ToUser();
            return user;
        }

        public async Task DeleteAsync(User user)
        {
            var entity = user.ToDbEntity();
            await repository.DeleteAsync(entity);
        }

        public async Task AssignEventsToUserAsync(string userId, IEnumerable<string> eventIds)
        {
            var evIds = new List<Guid>();

            eventIds.ToList().ForEach(eventId =>  evIds.Add(Guid.Parse(eventId)));
            var user = await GetByIdAsync(userId);
            user.AddEvents(evIds);

            var entity = user.ToDbEntity();
            await repository.AssignEventsToUserAsync(entity);
        }
    }
}
