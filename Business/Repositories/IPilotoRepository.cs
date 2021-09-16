using System.Collections.Generic;
using Business.Entities;

namespace Business.Repositories
{
    public interface IPilotoRepository
    {
        void Adicionar(Piloto piloto);
        void Commit();

        IList<Nave> obterPorPiloto(int idPiloto);
    }
}