using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.Repositories;
using System;

namespace Fiap.Exemplo02.MVC.Web.UnitsOfWork
{
    class UnitOfWork : IDisposable
    {
        private PortalFiapContext _context = new PortalFiapContext();

        private IGenericRepository<Aluno> _alunoRepository;
        private IGenericRepository<Grupo> _grupoRepository;
        private IGenericRepository<Projeto> _projetoRepository;
        private IProfessorRepository _professorRepository;

        public IGenericRepository<Aluno> AlunoRepository
        {
            get
            {
                if (_alunoRepository == null)
                {
                    _alunoRepository = new GenericRepository<Aluno>(_context);
                }
                return _alunoRepository;
            }
        }

        public IGenericRepository<Grupo> GrupoRepository
        {
            get
            {
                if (_grupoRepository == null)
                {
                    _grupoRepository = new GenericRepository<Grupo>(_context);
                }
                return _grupoRepository;
            }
        }
        
        public IGenericRepository<Projeto> ProjetoRepository
        {
            get
            {
                if (_projetoRepository == null)
                {
                    _projetoRepository = new GenericRepository<Projeto>(_context);
                }
                return _projetoRepository;
            }
        }
        public IProfessorRepository ProfessorRepository
        {
            get
            {
                if (_professorRepository == null)
                {
                    _professorRepository = new ProfessorRepository(_context);
                }
                return _professorRepository;
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