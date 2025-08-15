using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data;

namespace AmbarYonetimi.filters
{
    public class AuthFilter : IActionFilter
    {
        private readonly string _role;

        public AuthFilter(string role)
        {
            _role = role;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            var userRole = context.HttpContext.Session.GetString("Role");

            if (userRole == null || userRole != _role)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }


    }
}