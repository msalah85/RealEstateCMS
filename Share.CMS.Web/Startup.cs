using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Share.CMS.Web.Startup))]
namespace Share.CMS.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
