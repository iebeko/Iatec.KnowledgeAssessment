using System.Web.Mvc;

namespace Iatec.Knowledge.Assesment.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}