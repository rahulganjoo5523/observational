using Microsoft.ApplicationInsights;
using System;
using System.Web.Mvc;

namespace NBA.ArenaManagement.WebApp.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AppInsightsTelemetryAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext != null && filterContext.HttpContext != null && filterContext.Exception != null)
            {
                /*...If customError is Off, then AI HTTPModule will report the exception 
                 * else in case of RemoteOnly (default) or On, below will take care of reporting it ...*/
                if (filterContext.HttpContext.IsCustomErrorEnabled)
                {   
                    var ai = new TelemetryClient();
                    ai.TrackException(filterContext.Exception);
                }
            }
            base.OnException(filterContext);
        }
    }
}