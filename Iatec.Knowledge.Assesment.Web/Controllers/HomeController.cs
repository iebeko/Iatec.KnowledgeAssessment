using System.Web.Mvc;

namespace Iatec.Knowledge.Assesment.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Events() 
        {
            return View();
        }
    }
}
