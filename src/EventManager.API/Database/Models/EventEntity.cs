using EventManager.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventManager.API.Database.Models
{
    public class EventEntity : DbBaseEntity, IHasNavigationLoad
    {
        public Guid SpeakerId { get; set; } = default!;
        public UserEntity? Speaker { get; set; }
        public TopicEntity? Topic { get; set; }
        public Guid TopicId { get; set; } = default!;
        public DateTime DateTime { get; set; } = default!;
        public bool IsSpeakerActive { get; set; }
        public ICollection<UserEventEntity>? UserEvents { get; set; } = new List<UserEventEntity>();

        public async Task LoadNavigationsAsync(DbContext context)
        {
            await context.Entry(this).Reference(e => e.Speaker).LoadAsync();
            await context.Entry(this).Reference(e => e.Topic).LoadAsync();
        }
    }
}
