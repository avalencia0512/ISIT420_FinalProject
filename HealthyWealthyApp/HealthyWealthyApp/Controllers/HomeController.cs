using System.Web.Mvc;

namespace HealthyWealthyApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Happy Wealthy Analysis";

            return View();
        }
    }
}
