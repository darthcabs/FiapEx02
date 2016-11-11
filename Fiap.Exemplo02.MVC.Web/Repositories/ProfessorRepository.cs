using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Fiap.Exemplo02.MVC.Web.Models;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(PortalFiapContext context):base(context)
        {
        }

        public void Promocao(int id, decimal valor)
        {
            Professor professor = BuscarPorId(id);
            professor.Salario += valor * professor.Salario;
        }
    }
}
