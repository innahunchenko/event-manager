using Microsoft.AspNetCore.Mvc;

namespace EventManager.API.Common
{
    public static class ResultExtensions
    {
        public static IActionResult ToActionResult<TValue>(
            this Result<TValue> result,
            Func<TValue, IActionResult> onSuccess)
        {
            return result.IsSuccess
                ? onSuccess(result.Value)
                : CustomResults.Problem(result.Error);
        }

        public static IActionResult ToActionResult(
            this Result result,
            Func<IActionResult> onSuccess)
        {
            return result.IsSuccess
                ? onSuccess()
                : CustomResults.Problem(result.Error);
        }
    }
}
