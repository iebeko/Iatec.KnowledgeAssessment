using System.Web.Mvc;

namespace Iatec.Knowledge.Assesment.Web.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize]
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.UserName = User.Identity.Name;
            return View();
        }
        
    }
}