using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class AlunoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        #region GET
        public ActionResult Buscar(string nomeBusca, int? idGrupo)
        {
            List<Aluno> alunos = null;
            if (idGrupo == null)
            {
                alunos = _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca)).ToList();
            }
            else
            {
                alunos = _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca) && 
                                                         a.GrupoId == idGrupo).ToList();
            }
            
            //return View() -> Direciona para uma view
            //return RedirectToAction() -> Chama um método do controller
            return View("Listar", alunos);
        }

        public ActionResult Listar()
        {
            //.Include("Professor") -> Faz com que ao buscar a lista de alunos, ele traga também todos
            // os professores associados ao aluno
            //List<Aluno> alunos = contexto.Aluno.Include("Professor").ToList();

            List<Aluno> alunos = _unit.AlunoRepository.Listar().ToList();
            CarregarComboGrupo();

            return View(alunos);
        }
        
        public ActionResult Cadastrar()
        {
            List<Grupo> grupos = _unit.GrupoRepository.Listar().ToList();
            ViewBag.grupos = new SelectList(grupos, "Id", "Nome");

            return View();
        }

        public ActionResult Alterar(int id)
        {
            Aluno aluno = _unit.AlunoRepository.BuscarPorId(id);
            return View(aluno);
        }
        #endregion

        #region POST
        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            try
            {
                _unit.AlunoRepository.Cadastrar(aluno);
                _unit.Salvar();
                TempData["mensagem"] = "Aluno cadastrado";
            }
            catch (DbUpdateException)
            {
                TempData["mensagem"] = "Falha ao cadastrar aluno. Reveja os dados e tente novamente";
            }
            
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Alterar(Aluno aluno)
        {
            try
            {
                _unit.AlunoRepository.Atualizar(aluno);
                _unit.Salvar();
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
                Aluno aluno = _unit.AlunoRepository.BuscarPorId(id);
                _unit.AlunoRepository.Remover(aluno);
                _unit.Salvar();
                TempData["mensagem"] = "Aluno excluído com sucesso";
            }
            catch (Exception)
            {
                TempData["mensagem"] = "Falha ao excluir o aluno. Tente novamente.";
            }
            
            return RedirectToAction("Listar");
        }

        #endregion

        private void CarregarComboGrupo()
        {
            ViewBag.grupos = new SelectList(_unit.GrupoRepository.Listar(), "Id", "Nome");
        }

        #region DISPOSE
        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
        #endregion
    }
}