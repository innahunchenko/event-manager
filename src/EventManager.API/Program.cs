using EventManager.API.Common;
using EventManager.API.Database;
using EventManager.API.Repositories;
using EventManager.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddScoped<IEventService, EventService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();
await app.InitialiseDatabaseAsync();

app.UseSwagger();
app.UseSwaggerUI();
app.UseExceptionHandler();
app.MapControllers(); 

app.Run();
