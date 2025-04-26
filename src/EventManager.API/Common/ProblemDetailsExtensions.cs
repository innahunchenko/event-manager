using Microsoft.AspNetCore.Mvc;

namespace EventManager.API.Common
{
    public static class ProblemDetailsExtensions
    {
        public static ProblemDetails ToProblemDetails(this Error error)
        {
            return new ProblemDetails
            {
                Status = GetStatusCode(error.Type),
                Type = GetType(error.Type),
                Title = error.Code,
                Detail = error.Description
            };
        }

        private static int GetStatusCode(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

        private static string GetType(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Validation => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                ErrorType.NotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                ErrorType.Unauthorized => "https://tools.ietf.org/html/rfc7235#section-3.1",
                _ => "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };
    }
}
