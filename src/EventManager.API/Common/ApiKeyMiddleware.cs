using EventManager.API.Errors;

namespace EventManager.API.Common
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration configuration;
        private static readonly HashSet<string> ExemptPaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "/swagger",
                "/swagger-ui",
                "/swagger/v1/swagger.json" 
            };

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this.next = next;
            this.configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (ExemptPaths.Any(path => context.Request.Path.StartsWithSegments(path)))
            {
                await next(context);
                return;
            }

            const string apiKeyHeaderName = "X-Api-Key";

            if (!context.Request.Headers.TryGetValue(apiKeyHeaderName, out var providedApiKey))
            {
                throw new AppException(InfrastructureErrors.Security.InvalidApiKey);
            }

            var expectedApiKey = configuration["ApiKey"];

            if (string.IsNullOrWhiteSpace(expectedApiKey) || providedApiKey != expectedApiKey)
            {
                throw new AppException(InfrastructureErrors.Security.InvalidApiKey);
            }

            await next(context);
        }
    }
}
