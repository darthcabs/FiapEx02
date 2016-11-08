using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Fiap.Exemplo02.MVC.Web.Models;
using System.Data.Entity;
using System.Linq;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    class GrupoRepository : IGrupoRepository
    {
        private PortalFiapEntities _context;

        public GrupoRepository(PortalFiapEntities context)
        {
            _context = context;
        }

        public void Atualizar(Grupo grupo)
        {
            _context.Entry(grupo).State = EntityState.Modified;
        }

        public ICollection<Grupo> BuscarPor(Expression<Func<Grupo, bool>> filtro)
        {
            return _context.Grupo.Where(filtro).ToList();
        }

        public Grupo BuscarPorId(int id)
        {
            return _context.Grupo.Find(id);
        }

        public void Cadastrar(Grupo grupo)
        {
            _context.Grupo.Add(grupo);
        }

        public ICollection<Grupo> Listar()
        {
            return _context.Grupo.ToList();
        }

        public void Remover(int id)
        {
            Grupo grupo = _context.Grupo.Find(id);
            _context.Grupo.Remove(grupo);
        }
    }
}