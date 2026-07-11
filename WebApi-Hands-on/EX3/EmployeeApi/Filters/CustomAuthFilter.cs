using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeApi.Filters
{
    // Inheriting from ActionFilterAttribute as requested
    public class CustomAuthFilter : ActionFilterAttribute
    {
        // Intercepting the request
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // 1. Check if 'Authorization' header is completely missing
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                context.Result = new BadRequestObjectResult("Invalid request - No Auth token");
                return;
            }

            // 2. Check if the header exists, but is missing the word 'Bearer'
            var authHeader = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (!authHeader.Contains("Bearer"))
            {
                context.Result = new BadRequestObjectResult("Invalid request - Token present but Bearer unavailable");
                return;
            }

            // If it passes both checks, let the request through to the controller
            base.OnActionExecuting(context);
        }
    }
}