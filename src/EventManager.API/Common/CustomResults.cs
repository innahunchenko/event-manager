using Microsoft.AspNetCore.Mvc;

namespace EventManager.API.Common
{
    public static class CustomResults
    {
        public static IActionResult Problem(Error error)
        {
            var problemDetails = error.ToProblemDetails();

            if (error is ValidationError validationError)
            {
                problemDetails.Extensions["errors"] = validationError.Errors;
            }

            return new ObjectResult(problemDetails)
            {
                StatusCode = problemDetails.Status
            };
        }
    }
}
