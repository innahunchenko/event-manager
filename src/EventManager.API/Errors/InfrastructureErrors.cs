using EventManager.API.Common;

namespace EventManager.API.Errors
{
    public static class InfrastructureErrors
    {
        public static class Security
        {
            public static readonly Error InvalidApiKey =
                Error.Unauthorized("Security.InvalidApiKey", "Invalid or missing API Key.");
        }
    }
}
