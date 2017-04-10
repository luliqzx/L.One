using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(L.One.WebApp.Startup))]
namespace L.One.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
