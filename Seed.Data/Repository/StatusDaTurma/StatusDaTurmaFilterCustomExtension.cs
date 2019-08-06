using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class StatusDaTurmaFilterCustomExtension
    {

        public static IQueryable<StatusDaTurma> WithCustomFilters(this IQueryable<StatusDaTurma> queryBase, StatusDaTurmaFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<StatusDaTurma> WithLimitTenant(this IQueryable<StatusDaTurma> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

