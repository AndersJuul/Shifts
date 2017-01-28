using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return File(Server.MapPath("Static/") + "index.html", "text/html");
            return File("index.html", "text/html");
        }
    }
}