using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.Repositories;
using System;

namespace Fiap.Exemplo02.MVC.Web.UnitsOfWork
{
    class UnitOfWork : IDisposable
    {
        private PortalFiapEntities _context = new PortalFiapEntities();

        private IAlunoRepository _alunoRepository;

        public IAlunoRepository AlunoRepository
        {
            get
            {
                if (_alunoRepository == null)
                {
                    _alunoRepository = new AlunoRepository(_context);
                }
                return _alunoRepository;
            }
        }

        private IGrupoRepository _grupoRepository;

        public IGrupoRepository GrupoRepository
        {
            get
            {
                if (_grupoRepository == null)
                {
                    _grupoRepository = new GrupoRepository(_context);
                }
                return _grupoRepository;
            }
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}