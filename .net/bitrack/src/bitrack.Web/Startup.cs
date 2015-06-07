using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bitrack.Web.Startup))]
namespace bitrack.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
