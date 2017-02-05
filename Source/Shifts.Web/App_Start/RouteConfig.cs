using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", 
                "{*.}", 
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}