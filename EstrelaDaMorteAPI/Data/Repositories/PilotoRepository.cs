using System.Collections.Generic;
using Business.Entities;
using Business.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infra.Data.Repositories
{
    public class PilotoRepository : IPilotoRepository
    {
        private readonly EstrelaDaMorteDbContext _context;

        public PilotoRepository(EstrelaDaMorteDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Piloto piloto)
        {
            _context.Pilotos.Add(piloto);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Piloto> obterPorPiloto(int idPiloto)
        {
            return _context.Pilotos.Include(i => i.IdPiloto).Where(w => w.IdPiloto == idPiloto).ToList();

        }
    }
}