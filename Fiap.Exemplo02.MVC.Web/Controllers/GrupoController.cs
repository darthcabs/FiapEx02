using Fiap.Exemplo02.MVC.Web.Models;
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
        PortalFiapEntities contexto = new PortalFiapEntities();
        // GET: Grupo
        public ActionResult Listar()
        {
            List<Grupo> grupos = contexto.Grupo.ToList();
            return View(grupos);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Alterar(int Id)
        {
            Grupo grupo = contexto.Grupo.Find(Id);
            return View(grupo);
        }

        [HttpPost]
        public ActionResult Cadastrar(Grupo grupo)
        {
            contexto.Grupo.Add(grupo);
            contexto.SaveChanges();
            TempData["mensagem"] = "Grupo cadastrado com sucesso.";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Alterar(Grupo grupo)
        {
            contexto.Entry(grupo).State = EntityState.Modified;
            contexto.SaveChanges();
            TempData["mensagem"] = "Grupo alterado com sucesso.";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Excluir(int Id)
        {
            Grupo grupo = contexto.Grupo.Find(Id);
            contexto.Grupo.Remove(grupo);
            TempData["mensagem"] = "Grupo excluído com sucesso";

            return RedirectToAction("Listar");
        }
    }
}