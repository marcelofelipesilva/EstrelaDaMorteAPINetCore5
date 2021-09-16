using System.Collections.Generic;
using Business.Entities;

namespace Business.Repositories
{
    public interface IPlanetaRepository
    {
        void Adicionar(Planeta planeta);
        void Commit();

        IList<Planeta> obterPorPlaneta(int idPlaneta);
    }
}