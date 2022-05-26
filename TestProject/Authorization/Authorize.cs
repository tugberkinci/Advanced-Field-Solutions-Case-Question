using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TestProject.Entities;

namespace TestProject.Authorization;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class Authorize : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // skip authorization if action is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;

            var user = (UserToken)context.HttpContext.Items["User"];

        if (user == null)
        {
           
            // not logged in - return 401 unauthorized
            context.Result = new JsonResult(new { Result= new
            {
                status = false,
                message = "Unauthorized User"

            }}){ StatusCode = StatusCodes.Status401Unauthorized };

            // set 'WWW-Authenticate' header to trigger login popup in browsers
            //context.HttpContext.Response.Headers["WWW-Authenticate"] = "Basic realm=\"\", charset=\"UTF-8\"";
        }
    }
}