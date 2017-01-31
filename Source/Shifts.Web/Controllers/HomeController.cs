using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return View();
            return File(Server.MapPath("/") +"index.html", "text/html");
        }
    }
}