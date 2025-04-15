using EventManager.API.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.API.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.Position).IsRequired();
            builder.Property(p => p.Company).IsRequired();
            builder.Property(p => p.YearsOfExperience).IsRequired();
            builder.Property(p => p.Role).IsRequired()
                .HasConversion<string>().HasDefaultValue(UserRole.Attendee);
        }
    }
}
