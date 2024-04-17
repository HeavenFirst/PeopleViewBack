using Microsoft.AspNetCore.Mvc;

namespace PeopleViewBack.Controllers
{
    public class BaseController : ControllerBase
    {
        protected async Task<IActionResult> ExceptionHandling(Exception ex,
            string? message = null)
        {
            var logText = $"{message}{Environment.NewLine}{ex.StackTrace}";

            //There should be an action to save the logs

            message ??= $"Internal server error";

            return StatusCode(
                500,
                new
                {
                    Data = new { message }
                });
        }
    }
}
