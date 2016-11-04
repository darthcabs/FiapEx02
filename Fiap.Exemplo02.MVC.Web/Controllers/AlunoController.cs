using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class AlunoController : Controller
    {
        private PortalFiapEntities contexto = new PortalFiapEntities();

        // GET: Aluno
        public ActionResult Listar()
        {
            List<Aluno> alunos = contexto.Aluno.ToList();
            return View(alunos);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Alterar(int id)
        {
            Aluno aluno = contexto.Aluno.Find(id);
            return View(aluno);
        }

        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            contexto.Aluno.Add(aluno);
            contexto.SaveChanges();
            TempData["mensagem"] = "Aluno cadastrado";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Alterar(Aluno alunoForm)
        {
            Aluno aluno = contexto.Aluno.Find(alunoForm.Id);
            aluno.Nome = alunoForm.Nome;
            aluno.DataNascimento = alunoForm.DataNascimento;
            aluno.Bolsa = alunoForm.Bolsa;
            aluno.Desconto = alunoForm.Desconto;
            contexto.SaveChanges();
            TempData["mensagem"] = "Dados do aluno alterados";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            Aluno aluno = contexto.Aluno.Find(id);
            contexto.Aluno.Remove(aluno);
            contexto.SaveChanges();
            TempData["mensagem"] = "Aluno excluído com sucesso";
            return RedirectToAction("Listar");
        }
    }
}