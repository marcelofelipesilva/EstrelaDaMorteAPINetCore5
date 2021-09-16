using System.Collections.Generic;
using Business.Entities;
using Business.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class NaveRepository : INaveRepository
    {
        private readonly EstrelaDaMorteDBContext _context;
        public NaveRepository(EstrelaDaMorteDBContext context)
        {
            _context = context;
        }
        
        public void Adicionar(Nave nave)
        {
            _context.Naves.Add(nave);
           
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Nave> obterPorNaves(int idNave)
        {
            return _context.Naves.Include(i => i.IdNave).Where(w => w.IdNave == idNave).ToList();
        }
    }
}