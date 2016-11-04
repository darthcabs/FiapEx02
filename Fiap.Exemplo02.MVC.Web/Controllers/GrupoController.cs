using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class GrupoController : Controller
    {
        PortalContext contexto = new PortalContext();
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

        [HttpPost]
        public ActionResult Cadastrar(Grupo grupo)
        {
            // TO-DO
            return RedirectToAction("Listar");
        }
    }
}