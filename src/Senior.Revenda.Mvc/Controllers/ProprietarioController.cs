using Senior.Revenda.Contract.Applications;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Senior.Revenda.Mvc.Controllers
{
    public class ProprietarioController : BaseController
    {
        private readonly IProprietarioApplication _proprietarioApplication;
        private readonly IEstadoApplication _estadoApplication;

        public ProprietarioController(IProprietarioApplication proprietarioApplication
            , IEnderecoApplication enderecoApplication
            , IEstadoApplication estadoApplication)
        {
            _proprietarioApplication = proprietarioApplication;
            _estadoApplication = estadoApplication;
            _enderecoApplication = enderecoApplication;
        }

        public ActionResult Index()
        {
            return View(new ProprietarioFilterDTO());
        }

        public ActionResult Cadastrar()
        {
            GetViewBag();
            return View(new ProprietarioDTO());
        }

        public ActionResult Alterar(Guid id)
        {
            var result = _proprietarioApplication.Get(id);
            GetViewBag();
            return View(result);
        }

        [HttpGet]
        public ActionResult Consultar(ProprietarioFilterDTO filtro)
        {
            var result = _proprietarioApplication.GetByFilter(filtro);
            return View("Index", result);
        }

        [HttpPost]
        public ActionResult Cadastrar(ProprietarioDTO viewModel)
        {
            _proprietarioApplication.Create(viewModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Alterar(ProprietarioDTO viewModel)
        {
            _proprietarioApplication.Update(viewModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Cancelar(Guid id)
        {
            _proprietarioApplication.Cancelar(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Ativar(Guid id)
        {
            _proprietarioApplication.Ativar(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        private void GetViewBag()
        {
            var estados = _estadoApplication.GetAllAtivos();

            ViewBag.Estado = new SelectList(estados, "Id", "UF");
        }
    }
}