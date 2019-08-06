using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class TurmaParticipanteFilterCustomExtension
    {

        public static IQueryable<TurmaParticipante> WithCustomFilters(this IQueryable<TurmaParticipante> queryBase, TurmaParticipanteFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<TurmaParticipante> WithLimitTenant(this IQueryable<TurmaParticipante> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

