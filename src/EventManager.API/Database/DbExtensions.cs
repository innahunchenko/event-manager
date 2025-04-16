using EventManager.API.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.API.Database
{
    public static class DbExtensions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await context.Database.MigrateAsync();
            await SeedDataAsync(context);
        }

        private static async Task SeedDataAsync(AppDbContext context)
        {
            var hasAnyData = await context.Topics.AnyAsync()
                    || await context.Users.AnyAsync()
                    || await context.Events.AnyAsync()
                    || await context.UserEvents.AnyAsync();

            if (hasAnyData)
                return;

            var topic = new TopicEntity
            {
                Id = Guid.NewGuid(),
                Name = "Modern Microservices Architecture",
                Description = "Discussion on best practices for building scalable microservices with .NET and Azure.",
                IsActive = true
            };

            var speaker = new UserEntity
            {
                Id = Guid.NewGuid(),
                FirstName = "Alice",
                LastName = "Smith",
                Position = "Senior Cloud Architect",
                Company = "AzureExperts Inc.",
                YearsOfExperience = 10f,
                Role = UserRole.Speaker
            };

            var user = new UserEntity
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Position = "Software Engineer",
                Company = "TechCorp",
                YearsOfExperience = 5.5f,
                Role = UserRole.Attendee
            };

            var @event = new EventEntity
            {
                Id = Guid.NewGuid(),
                SpeakerId = speaker.Id,
                TopicId = topic.Id,
                DateTime = DateTime.UtcNow.AddDays(3),
                Agenda = "Introduction to Clean Architecture in .NET",
                IsSpeakerActive = true
            };

            speaker.UserEvents.Add(new UserEventEntity { UserId = Guid.Empty, EventId = @event.Id });
            user.UserEvents.Add(new UserEventEntity { UserId = Guid.Empty, EventId = @event.Id });

            context.Topics.Add(topic);
            context.Users.AddRange(speaker, user);
            context.Events.Add(@event);

            await context.SaveChangesAsync();

            //--

            topic = new TopicEntity
            {
                Id = Guid.NewGuid(),
                Name = "AI in Modern Applications",
                Description = "Exploration of AI integration in enterprise .NET apps.",
                IsActive = true
            };

            speaker = new UserEntity
            {
                Id = Guid.NewGuid(),
                FirstName = "Bob",
                LastName = "Johnson",
                Position = "AI Solutions Architect",
                Company = "IntelliTech",
                YearsOfExperience = 12f,
                Role = UserRole.Speaker
            };

            var user2 = new UserEntity
            {
                Id = Guid.NewGuid(),
                FirstName = "Emma",
                LastName = "Brown",
                Position = "Frontend Developer",
                Company = "WebWorks",
                YearsOfExperience = 3f,
                Role = UserRole.Attendee
            };

            var @event2 = new EventEntity
            {
                Id = Guid.NewGuid(),
                SpeakerId = speaker.Id,
                TopicId = topic.Id,
                DateTime = DateTime.UtcNow.AddDays(7),
                Agenda = "Leveraging OpenAI with .NET 8",
                IsSpeakerActive = true
            };

            speaker.UserEvents.Add(new UserEventEntity { UserId = Guid.Empty, EventId = @event2.Id });
            user2.UserEvents.Add(new UserEventEntity { UserId = Guid.Empty, EventId = @event2.Id });
            user2.UserEvents.Add(new UserEventEntity { UserId = Guid.Empty, EventId = @event.Id });

            context.Topics.Add(topic);
            context.Users.AddRange(speaker, user2);
            context.Events.Add(@event2);
            await context.SaveChangesAsync();
        }
    }
}
