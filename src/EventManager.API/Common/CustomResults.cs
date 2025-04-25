using Microsoft.AspNetCore.Mvc;

namespace EventManager.API.Common
{
    public static class CustomResults
    {
        public static IActionResult Problem(Error error)
        {
            return new ObjectResult(new ProblemDetails
            {
                Title = GetTitle(error),
                Detail = GetDetail(error),
                Type = GetType(error.Type),
                Status = GetStatusCode(error.Type),
                Extensions = { ["errors"] = GetErrors(error) }
            })
            {
                StatusCode = GetStatusCode(error.Type)
            };

            static string GetTitle(Error error) => error.Code;

            static string GetDetail(Error error) => error.Description;

            static string GetType(ErrorType errorType) =>
                errorType switch
                {
                    ErrorType.Validation => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    //ErrorType.Problem => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    ErrorType.NotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                    //ErrorType.Conflict => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
                    _ => "https://tools.ietf.org/html/rfc7231#section-6.6.1"
                };

            static int GetStatusCode(ErrorType errorType) =>
                errorType switch
                {
                    ErrorType.Validation => StatusCodes.Status400BadRequest,
                    ErrorType.NotFound => StatusCodes.Status404NotFound,
                   // ErrorType.Conflict => StatusCodes.Status409Conflict,
                    _ => StatusCodes.Status500InternalServerError
                };

            static object? GetErrors(Error error)
            {
                if (error is not ValidationError validationError)
                    return null;

                return validationError.Errors;
            }
        }
    }
}
