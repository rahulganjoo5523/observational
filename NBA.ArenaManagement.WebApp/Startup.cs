using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NBA.ArenaManagement.WebApp.Startup))]

namespace NBA.ArenaManagement.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
