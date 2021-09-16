using System.Collections.Generic;
using Business.Entities;
using Business.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class PlanetaRepository : IPlanetaRepository
    {
        private readonly EstrelaDaMorteDbContext _context;

        public PlanetaRepository(EstrelaDaMorteDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Planeta planeta)
        {
            _context.Planetas.Add(planeta);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Planeta> obterPorPlaneta(int idPlaneta)
        {
            return _context.Planetas.Include(i => i.IdPlaneta).Where(w => w.IdPlaneta == idPlaneta).ToList();
        }
    }
}