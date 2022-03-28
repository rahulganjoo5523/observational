using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.WsFederation;
using Owin;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NBA.ArenaManagement.WebApp
{
    public partial class Startup
    {
        private static string realm = ConfigurationManager.AppSettings["ida:Wtrealm"];
        private static string adfsMetadata = ConfigurationManager.AppSettings["ida:Metadata"];
        private static string reply = ConfigurationManager.AppSettings["ida:WReply"];

        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                CookieManager = new SystemWebChunkingCookieManager()
            }); 

            app.UseWsFederationAuthentication(
                new WsFederationAuthenticationOptions
                {
                    Wtrealm = realm,
                    Wreply = reply,
                    MetadataAddress = adfsMetadata,
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = ConfigurationManager.AppSettings["ida:TrustIssuer"],
                        ValidateAudience = false
                    },
                    Notifications = new WsFederationAuthenticationNotifications
                    {
                        SecurityTokenValidated = context =>
                        {
                            //... Get the email from the auth ticket issued after user is authenticated with AAD ...
                            var email = context.AuthenticationTicket.Identity.Claims.Where(x => x.Type
                                == System.IdentityModel.Claims.ClaimTypes.Email).Select(x => x.Value).FirstOrDefault();

                            //... Using the email as primary identifier, fetch the user detail form ADB custom user store ...
                            var db = new ArenaDBModelContainer();
                            var user = db.Users.Where(x => x.Email.Trim().ToUpper() == email.Trim().ToUpper()).FirstOrDefault();

                            var role = (null != user) ? user.Role : string.Empty;
                            var arena = (null != user) ? user.Arena : string.Empty;

                            //... Add custom role and arena name claim to the auth identity ...
                            context.AuthenticationTicket.Identity.AddClaim(
                                                                new Claim(ClaimTypes.Role, role));
                            context.AuthenticationTicket.Identity.AddClaim(
                                                                new Claim("arena", arena));

                            return Task.FromResult(0);
                        }
                    }
                });
        }
    }
}