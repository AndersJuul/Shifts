using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Shifts.Drivers.Web.Lib;

[assembly: OwinStartup(typeof(Startup))]

namespace Shifts.Drivers.Web.Lib
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        //
        public void Configuration(IAppBuilder appBuilder)
        {
            // We're going to hang the web API off off the /api "sub"-url so that we
            //  leave the root url open for the Angular 2 website.
            //
            appBuilder.Map("/api", api =>
            {
                // Create our config object we'll use to configure the API
                //
                var config = new HttpConfiguration();

                // Use attribute routing
                //
                config.MapHttpAttributeRoutes();

                // Now add in the WebAPI middleware
                //
                api.UseWebApi(config);
            });
        }
    }
}
