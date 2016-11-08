using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Fiap.Exemplo02.MVC.Web.Models;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private PortalFiapEntities _context;

        public AlunoRepository(PortalFiapEntities context)
        {
            _context = context;
        }

        public void Atualizar(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
        }

        public ICollection<Aluno> BuscarPor(Expression<Func<Aluno, bool>> filtro)
        {
            return _context.Aluno.Where(filtro).ToList();
        }

        public Aluno BuscarPorId(int id)
        {
            return _context.Aluno.Find(id);
        }

        public void Cadastrar(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
        }

        public ICollection<Aluno> Listar()
        {
            return _context.Aluno.ToList();
        }

        public void Remover(int id)
        {
            Aluno aluno = _context.Aluno.Find(id);
            _context.Aluno.Remove(aluno);
        }
    }
}