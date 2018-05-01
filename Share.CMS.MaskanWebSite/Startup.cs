using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Share.CMS.MaskanWebSite.Startup))]
namespace Share.CMS.MaskanWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
