using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Defasio.Nibo.Mvc.Startup))]
namespace Defasio.Nibo.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
