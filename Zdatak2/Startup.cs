using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zdatak2.Startup))]
namespace Zdatak2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
