using EventManager.API.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.API.Database.Configurations
{
    public class UserEventConfiguration : IEntityTypeConfiguration<UserEventEntity>
    {
        public void Configure(EntityTypeBuilder<UserEventEntity> builder)
        {
            builder.ToTable("UserEvents");
            builder.HasKey(k => k.Id);
            builder.HasIndex(ue => new { ue.UserId, ue.EventId }).IsUnique();
            builder.HasOne<UserEntity>()
                .WithMany(u => u.UserEvents).HasForeignKey(ue => ue.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<EventEntity>()
                .WithMany(e => e.UserEvents).HasForeignKey(ue => ue.EventId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
