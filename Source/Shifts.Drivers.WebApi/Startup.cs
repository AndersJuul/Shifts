using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Shifts.Drivers.WebApi.Startup))]

namespace Shifts.Drivers.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
