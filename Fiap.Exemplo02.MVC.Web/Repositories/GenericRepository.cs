﻿using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        protected PortalFiapContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(PortalFiapContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual void Atualizar(T entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
        }

        public virtual ICollection<T> BuscarPor(Expression<Func<T, bool>> filtro)
        {
            return _dbSet.Where(filtro).ToList();
        }

        public virtual T BuscarPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Cadastrar(T entidade)
        {
            _dbSet.Add(entidade);
        }

        public virtual ICollection<T> Listar()
        {
            return _dbSet.ToList();
        }

        public virtual void Remover(T entidade)
        {
            _dbSet.Remove(entidade);
        }
    }
}
