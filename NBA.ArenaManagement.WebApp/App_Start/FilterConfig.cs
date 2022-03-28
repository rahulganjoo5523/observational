using NBA.ArenaManagement.WebApp.Filters;
using System.Web;
using System.Web.Mvc;

namespace NBA.ArenaManagement.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new NoRoleFilter());
            filters.Add(new AppInsightsTelemetryAttribute());
        }
    }
}
