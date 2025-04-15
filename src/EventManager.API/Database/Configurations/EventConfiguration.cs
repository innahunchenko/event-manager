using EventManager.API.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.API.Database.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<EventEntity>
    {
        public void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            builder.ToTable("Events");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Agenda).IsRequired();
            builder.Property(p => p.DateTime).IsRequired();
            builder.HasOne<UserEntity>()
                .WithMany().HasForeignKey(k => k.SpeakerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<TopicEntity>()
                .WithMany().HasForeignKey(k => k.SpeakerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
