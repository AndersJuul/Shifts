using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Shifts.Drivers.Web.Lib;

[assembly: OwinStartup(typeof(Startup))]

namespace Shifts.Drivers.Web.Lib
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.Map("/api", api =>
            {
                var config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();
                api.UseWebApi(config);
            });
        }
    }
}
