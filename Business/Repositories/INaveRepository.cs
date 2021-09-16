using System.Collections.Generic;
using Business.Entities;

namespace Business.Repositories
{
    public interface INaveRepository
    {
        void Adicionar(Nave nave);
        void Commit();

        IList<Nave> obterPorNaves(int idNave);
    }
}