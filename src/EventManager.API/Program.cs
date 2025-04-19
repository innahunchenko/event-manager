using EventManager.API.Database;
using EventManager.API.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();
await app.InitialiseDatabaseAsync();

app.MapEventEndpoints();
app.Run();
