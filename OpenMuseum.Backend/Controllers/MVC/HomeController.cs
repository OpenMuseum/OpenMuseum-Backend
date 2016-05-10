using System.Web.Mvc;

namespace OpenMuseum.Backend.Controllers.MVC
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}