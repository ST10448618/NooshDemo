using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NooshApp.Helpers;

namespace NooshApp.Middleware
{
    /// <summary>
    /// Action filter that redirects to /Account/Login if the user isn't logged in.
    /// Usage: decorate a controller or action with [RequireLogin].
    /// </summary>
    public class RequireLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Session.IsLoggedIn())
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }

            base.OnActionExecuting(context);
        }
    }
}