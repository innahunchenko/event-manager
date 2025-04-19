using EventManager.API.Domain;
using EventManager.API.Mapping;
using EventManager.API.Requests;
using EventManager.API.Responses;
using EventManager.API.Services;

namespace EventManager.API.Endpoints
{
    public static class TopicEndpoints
    {
        private static string baseRoute = "/api/topics";
        public static IEndpointRouteBuilder MapTopicEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapCrudEndpoints<TopicRequest, Topic, TopicResponse, TopicService>(
                baseRoute: baseRoute,
                mapToDomain: req => req.ToTopic(),
                mapToResponse: t => t.ToResponse(),
                getByIdAsync: (s, id) => s.GetByIdAsync(id),
                getAllAsync: s => s.GetAllAsync(),
                createAsync: (s, t) => s.CreateAsync(t),
                updateAsync: (s, t) => s.UpdateAsync(t),
                deleteAsync: (s, t) => s.DeleteAsync(t)
            );

            return app;
        }
    }
}
