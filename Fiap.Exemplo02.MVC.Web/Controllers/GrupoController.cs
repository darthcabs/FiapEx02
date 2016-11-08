using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class GrupoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();
        // GET: Grupo
        public ActionResult Listar()
        {
            List<Grupo> grupos = _unit.GrupoRepository.Listar().ToList();
            return View(grupos);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Alterar(int Id)
        {
            Grupo grupo = _unit.GrupoRepository.BuscarPorId(Id);
            return View(grupo);
        }

        [HttpPost]
        public ActionResult Cadastrar(Grupo grupo)
        {
            _unit.GrupoRepository.Cadastrar(grupo);
            TempData["mensagem"] = "Grupo cadastrado com sucesso.";
            _unit.Salvar();

            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Alterar(Grupo grupo)
        {
            _unit.GrupoRepository.Atualizar(grupo);
            TempData["mensagem"] = "Grupo alterado com sucesso.";
            _unit.Salvar();

            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Excluir(int Id)
        {
            _unit.GrupoRepository.Remover(Id);
            TempData["mensagem"] = "Grupo excluído com sucesso";
            _unit.Salvar();

            return RedirectToAction("Listar");
        }
        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}