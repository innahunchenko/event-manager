using EventManager.API.Domain;
using EventManager.API.Mapping;
using EventManager.API.Requests;
using EventManager.API.Responses;
using EventManager.API.Services;

namespace EventManager.API.Endpoints
{
    public static class EventEndpoints
    {
        private static string baseRoute = "/api/events";
        public static IEndpointRouteBuilder MapEventEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapCrudEndpoints<EventRequest, Event, EventResponse, EventService>(
                baseRoute: baseRoute,
                mapToDomain: req => req.ToEvent(),
                mapToResponse: e => e.ToResponse(),
                getByIdAsync: (s, id) => s.GetByIdAsync(id),
                getAllAsync: s => s.GetAllAsync(),
                createAsync: (s, e) => s.CreateAsync(e),
                updateAsync: (s, e) => s.UpdateAsync(e),
                deleteAsync: (s, e) => s.DeleteAsync(e)
            );

            return app;
        }

        //app.MapPatch("/api/events/{id:guid}/deactivate-speaker", async (Guid id, EventService service) =>
        //{
        //    var existing = await service.GetByIdAsync(id);
        //    if (existing is null)
        //        return Results.NotFound();

        //    existing.DeactivateSpeaker();
        //    await service.UpdateAsync(existing);

        //    return Results.NoContent();
        //});
    }
}