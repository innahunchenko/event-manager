using EventManager.API.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.API.Database.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<TopicEntity>
    {
        public void Configure(EntityTypeBuilder<TopicEntity> builder)
        {
            builder.ToTable("Topics");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.IsActive).HasDefaultValue(true);
        }
    }
}
