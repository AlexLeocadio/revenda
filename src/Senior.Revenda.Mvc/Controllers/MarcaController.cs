using Senior.Revenda.Contract.Applications;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using System;
using System.Web.Mvc;

namespace Senior.Revenda.Mvc.Controllers
{
    public class MarcaController : BaseController
    {
        private readonly IMarcaApplication _marcaApplication;

        public MarcaController(IMarcaApplication marcaApplication)
        {
            _marcaApplication = marcaApplication;
        }

        public ActionResult Index()
        {
            return View(new MarcaFilterDTO());
        }

        public ActionResult Cadastrar()
        {
            return View(new MarcaDTO());
        }

        [HttpGet]
        public ActionResult Consultar(MarcaFilterDTO filtro)
        {
            var result = _marcaApplication.GetByFilter(filtro);
            return View("Index", result);
        }

        [HttpPost]
        public ActionResult Cadastrar(MarcaDTO viewModel)
        {
            _marcaApplication.Create(viewModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Cancelar(Guid id)
        {
            _marcaApplication.Cancelar(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Ativar(Guid id)
        {
            _marcaApplication.Ativar(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}