using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shifts.MainWeb.Startup))]
namespace Shifts.MainWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
