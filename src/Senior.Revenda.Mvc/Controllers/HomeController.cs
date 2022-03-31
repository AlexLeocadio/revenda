using System.Web.Mvc;

namespace Senior.Revenda.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}