using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.WsFederation;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace NBA.ArenaManagement.WebApp.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        ArenaDBModelContainer db = new ArenaDBModelContainer();

        public ActionResult Index()
        {
            if (Session["Role"] != null)
            {
                //User already authenticated
                if (Session["Role"].ToString() == "League")
                    return RedirectToAction("Index", "ArenaDynamic");
                else
                    return RedirectToAction("Details", "ArenaDynamic", new { id = Session["TeamId"].ToString() });
            }
            else
            {
                Session["Role"]
                        = ((ClaimsIdentity)System.Threading.Thread.CurrentPrincipal.Identity).Claims.Where(x => x.Type
                                == ClaimTypes.Role).Select(x => x.Value).FirstOrDefault();

                Session["Name"]
                         = ((ClaimsIdentity)System.Threading.Thread.CurrentPrincipal.Identity).Claims.Where(x => x.Type
                                == System.IdentityModel.Claims.ClaimTypes.Email).Select(x => x.Value).FirstOrDefault();

                var arena
                        = ((ClaimsIdentity)System.Threading.Thread.CurrentPrincipal.Identity).Claims.Where(x => x.Type
                                == "arena").Select(x => x.Value).FirstOrDefault();

                if (Session["Role"].ToString() == "League")
                {
                    Session["TeamName"] = "League";
                    return RedirectToAction("Index", "ArenaDynamic");
                }
                else
                {
                    var a = db.Arenas.Where(x => x.Name == arena).FirstOrDefault();
                    Session["TeamName"] = a.Name;
                    Session["TeamId"] = a.Id;
                    return RedirectToAction("Details", "ArenaDynamic", new { id = a.Id });
                }
            }
        }

        public void LogOff()
        {
            if (User.Identity.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.SignOut(
                WsFederationAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
            }
            else
            {
                throw new InvalidOperationException("User is not authenticated");
            }
        }
    }
}