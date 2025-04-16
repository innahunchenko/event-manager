using EventManager.API.Database.Models;
using EventManager.API.Domain;
using EventManager.API.Mapping;
using EventManager.API.Repositories;

namespace EventManager.API.Services
{
    public class UserService : IBaseService<User>
    {
        private readonly IBaseRepository<UserEntity> repository;

        public UserService(IBaseRepository<UserEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var userEntity = await repository.GetByIdAsync(id);
            var user = userEntity.ToDomain();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var userEntities = await repository.GetAllAsync();
            var users = userEntities.Select(u => u.ToDomain()).ToList();
            return users;
        }

        public async Task<User> CreateAsync(User user)
        {
            var userEntity = user.ToEntity();
            userEntity = await repository.CreateAsync(userEntity);
            user = userEntity.ToDomain();
            return user;
        }

        public async Task CreateRangeAsync(IEnumerable<User> users)
        {
            var entities = users.Select(u => u.ToEntity()).ToList();
            await repository.CreateRangeAsync(entities);
        }

        public async Task UpdateAsync(User user)
        {
            var userEntity = user.ToEntity();
            await repository.UpdateAsync(userEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }
    }
}
