using Microsoft.EntityFrameworkCore;

namespace EventManager.API.Database
{
    public static class AppDbExtentions
    {
        public static async Task InitialiseDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await context.Database.MigrateAsync();
        }
    }
}
