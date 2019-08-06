using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class TurmaOrderCustomExtension
    {

        public static IQueryable<Turma> OrderByDomain(this IQueryable<Turma> queryBase, TurmaFilter filters)
        {
            return queryBase.OrderBy(_ => _.TurmaId);
        }

    }
}

