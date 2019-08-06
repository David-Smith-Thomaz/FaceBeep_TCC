using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class TurmaParticipanteOrderCustomExtension
    {

        public static IQueryable<TurmaParticipante> OrderByDomain(this IQueryable<TurmaParticipante> queryBase, TurmaParticipanteFilter filters)
        {
            return queryBase.OrderBy(_ => _.TurmaParticipanteId);
        }

    }
}

