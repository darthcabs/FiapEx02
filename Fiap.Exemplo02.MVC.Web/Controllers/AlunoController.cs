using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class AlunoController : Controller
    {
        private PortalContext contexto = new PortalContext();

        // GET: Aluno
        public ActionResult Buscar(string nomeBusca)
        {
            List<Aluno> alunos = contexto.Aluno.Where(a => a.Nome.Contains(nomeBusca)).ToList();
            
            //return View() -> Direciona para uma view
            //return RedirectToAction() -> Chama um método do controller
            return View("Listar", alunos);
        }

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
            try
            {
                contexto.Aluno.Add(aluno);
                contexto.SaveChanges();
                TempData["mensagem"] = "Aluno cadastrado";
            }
            catch (DbUpdateException)
            {
                TempData["mensagem"] = "Falha ao cadastrar aluno. Reveja os dados e tente novamente";
            }
            
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Alterar(Aluno alunoForm)
        {
            try
            {
                Aluno aluno = contexto.Aluno.Find(alunoForm.Id);
                aluno.Nome = alunoForm.Nome;
                aluno.DataNascimento = alunoForm.DataNascimento;
                aluno.Bolsa = alunoForm.Bolsa;
                aluno.Desconto = alunoForm.Desconto;
                contexto.SaveChanges();
                TempData["mensagem"] = "Dados do aluno alterados";
            }
            catch (Exception)
            {
                TempData["mensagem"] = "Falha ao alterar o aluno. Reveja os dados e tente novamente";
            }
            
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            try
            {
                Aluno aluno = contexto.Aluno.Find(id);
                contexto.Aluno.Remove(aluno);
                contexto.SaveChanges();
                TempData["mensagem"] = "Aluno excluído com sucesso";
            }
            catch (Exception)
            {
                TempData["mensagem"] = "Falha ao excluir o aluno. Tente novamente.";
            }
            
            return RedirectToAction("Listar");
        }
    }
}