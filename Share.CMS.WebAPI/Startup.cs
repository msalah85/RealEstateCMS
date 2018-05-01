using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Share.CMS.WebAPI.Startup))]
namespace Share.CMS.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
