using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class StatusDaTurmaOrderCustomExtension
    {

        public static IQueryable<StatusDaTurma> OrderByDomain(this IQueryable<StatusDaTurma> queryBase, StatusDaTurmaFilter filters)
        {
            return queryBase.OrderBy(_ => _.StatusDaTurmaId);
        }

    }
}

