using System.Configuration;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return View();
            return File(ConfigurationManager.AppSettings["baseurl"] +"index.html", "text/html");
        }
    }
}