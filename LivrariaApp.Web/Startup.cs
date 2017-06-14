using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LivrariaApp.Web.Startup))]
namespace LivrariaApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
