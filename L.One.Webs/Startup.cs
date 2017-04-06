using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(L.One.Webs.Startup))]
namespace L.One.Webs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
