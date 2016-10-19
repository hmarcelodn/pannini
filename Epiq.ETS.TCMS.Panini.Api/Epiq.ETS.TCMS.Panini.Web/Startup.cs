using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Epiq.ETS.TCMS.Panini.Web.Startup))]
namespace Epiq.ETS.TCMS.Panini.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
