using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Routing;

namespace NBA.ArenaManagement.WebApp.Filters
{
    public class NoRoleFilter: ActionFilterAttribute
    {
        readonly string[] Path_Exclusions = { "UNAUTHORIZED", "LOGOFF" };

        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            var role = ((ClaimsIdentity)System.Threading.Thread.CurrentPrincipal.Identity).Claims.Where(x => x.Type
                                   == ClaimTypes.Role).Select(x => x.Value).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(role) && (!__isExcludedPath(ctx)))
            {
                ctx.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Users", action = "Unauthorized" }));
            }
        }

        private bool __isExcludedPath(ActionExecutingContext ctx)
        {
            for(int i=0; i<Path_Exclusions.Length;i++)
            {
                if (ctx.HttpContext.Request.Path.ToUpper().Contains(Path_Exclusions[i]))
                    return true;
            }

            return false;
        }
    }
}