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
            builder.Property(p => p.DateTime).IsRequired();

            builder.Property(e => e.SpeakerId)
               .IsRequired(false); 

            builder.Property(e => e.TopicId)
               .IsRequired(false);

            builder.HasOne(e => e.Speaker)
               .WithMany()
               .HasForeignKey(e => e.SpeakerId)
               .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.Topic)
               .WithMany()
               .HasForeignKey(e => e.TopicId)
               .OnDelete(DeleteBehavior.SetNull);

            //builder.HasOne<UserEntity>()
            //    .WithMany().HasForeignKey(k => k.SpeakerId).OnDelete(DeleteBehavior.Restrict);
            //builder.HasOne<TopicEntity>()
            //    .WithMany().HasForeignKey(k => k.TopicId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
