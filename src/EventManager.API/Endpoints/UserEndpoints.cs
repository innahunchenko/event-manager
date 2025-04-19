using EventManager.API.Domain;
using EventManager.API.Mapping;
using EventManager.API.Requests;
using EventManager.API.Responses;
using EventManager.API.Services;

namespace EventManager.API.Endpoints
{
    public static class UserEndpoints
    {
        private static string baseRoute = "/api/users";
        public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapCrudEndpoints<UserRequest, User, UserResponse, IUserService>(
                baseRoute: baseRoute,
                mapToDomain: req => req.ToUser(),
                mapToResponse: u => u.ToResponse(),
                getByIdAsync: (s, id) => s.GetByIdAsync(id),
                getAllAsync: s => s.GetAllAsync(),
                createAsync: (s, u) => s.CreateAsync(u),
                updateAsync: (s, u) => s.UpdateAsync(u),
                deleteAsync: (s, u) => s.DeleteAsync(u)
            );

            app.MapPost("{baseRoute}/assign-events", async (AssignEventsRequest request, IUserService service) =>
            {
                var existing = await service.GetByIdAsync(request.Id);
                if (existing is null)
                    return Results.NotFound();

                await service.AssignEventsToUserAsync(request.Id, request.EventIds);
                return Results.NoContent();
            });

            return app;
        }
    }

}
