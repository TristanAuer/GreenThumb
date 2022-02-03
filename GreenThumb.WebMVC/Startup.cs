using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GreenThumb.WebMVC.Startup))]
namespace GreenThumb.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
