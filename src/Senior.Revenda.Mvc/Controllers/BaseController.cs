using Senior.Revenda.Contract.Applications;
using System.Web.Mvc;

namespace Senior.Revenda.Mvc.Controllers
{
    public class BaseController : Controller
    {
        protected IEnderecoApplication _enderecoApplication;

        [HttpGet]
        public JsonResult GetByCep(string cep)
        {
            var result = _enderecoApplication.GetByCep(cep);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}