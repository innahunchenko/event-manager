using EventManager.API.Domain;
using EventManager.API.Requests;
using EventManager.API.Services;

namespace EventManager.API.Endpoints
{
    public static class CrudEndpoints
    {
        public static IEndpointRouteBuilder MapCrudEndpoints<TRequest, TDomain, TResponse, TService>(
            this IEndpointRouteBuilder app,
            string baseRoute,
            Func<TRequest, TDomain> mapToDomain,
            Func<TDomain, TResponse> mapToResponse,
            Func<TService, string, Task<TDomain?>> getByIdAsync,
            Func<TService, Task<IEnumerable<TDomain>>> getAllAsync,
            Func<TService, TDomain, Task<TDomain>> createAsync,
            Func<TService, TDomain, Task<TDomain>> updateAsync,
            Func<TService, TDomain, Task> deleteAsync)
                where TDomain : IEntity
                where TService : IBaseService<TDomain>
                where TRequest : IRequest
        {
            app.MapPost($"{baseRoute}/create", async (TRequest request, TService service) =>
            {
                var domain = mapToDomain(request);
                domain = await createAsync(service, domain);
                var response = mapToResponse(domain);
                return Results.Ok(response);
            });

            app.MapGet(baseRoute, async (TService service) =>
            {
                var all = await getAllAsync(service);
                var response = all.Select(mapToResponse);
                return Results.Ok(response);
            });

            app.MapGet($"{baseRoute}/{{id}}", async (string id, TService service) =>
            {
                var entity = await getByIdAsync(service, id);
                return entity is not null
                    ? Results.Ok(mapToResponse(entity))
                    : Results.NotFound();
            });

            app.MapPut($"{baseRoute}/{{id}}", async (TRequest request, TService service) =>
            {
                var existing = await getByIdAsync(service, request.Id);
                if (existing is null)
                    return Results.NotFound();

                var domain = mapToDomain(request);
                domain = await updateAsync(service, domain);
                var response = mapToResponse(domain);
                return Results.Ok(response);
            });

            app.MapDelete($"{baseRoute}/{{id}}", async (string id, TService service) =>
            {
                var existing = await getByIdAsync(service, id);
                if (existing is null)
                    return Results.NotFound();

                await deleteAsync(service, existing);
                return Results.NoContent();
            });

            return app;
        }
    }
}
