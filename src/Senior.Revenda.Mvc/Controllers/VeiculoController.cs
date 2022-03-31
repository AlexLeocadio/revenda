using Senior.Revenda.Contract.Applications;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using System;
using System.Web.Mvc;

namespace Senior.Revenda.Mvc.Controllers
{
    public class VeiculoController : BaseController
    {

        private readonly IVeiculoApplication _veiculoApplication;
        private readonly IMarcaApplication _marcaApplication;
        private readonly IProprietarioApplication _proprietarioApplication;

        public VeiculoController(IVeiculoApplication veiculoApplication
            , IMarcaApplication marcaApplication
            , IProprietarioApplication proprietarioApplication)
        {
            _veiculoApplication = veiculoApplication;
            _marcaApplication = marcaApplication;
            _proprietarioApplication = proprietarioApplication;
        }

        public ActionResult Index()
        {
            GetViewBag();
            return View(new VeiculoFilterDTO());
        }

        public ActionResult Cadastrar()
        {
            GetViewBag();
            return View(new VeiculoDTO());
        }

        public ActionResult Alterar(Guid id)
        {
            var result = _veiculoApplication.Get(id);
            GetViewBag();
            return View(result);
        }

        [HttpGet]
        public ActionResult Consultar(VeiculoFilterDTO filtro)
        {
            var result = _veiculoApplication.GetByFilter(filtro);
            GetViewBag();
            return View("Index", result);
        }

        [HttpPost]
        public ActionResult Cadastrar(VeiculoDTO viewModel)
        {
            _veiculoApplication.Create(viewModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Alterar(VeiculoDTO viewModel)
        {
            _veiculoApplication.Update(viewModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Vender(Guid id)
        {
            _veiculoApplication.Vendido(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Indisponibilizar(Guid id)
        {
            _veiculoApplication.Indisponivel(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        private void GetViewBag()
        {
            var marcas = _marcaApplication.GetAllAtivos();

            ViewBag.Marca = new SelectList(marcas, "Id", "Nome");

            var proprietarios = _proprietarioApplication.GetAllAtivos();

            ViewBag.Proprietario = new SelectList(proprietarios, "Id", "Nome");
        }
    }
}