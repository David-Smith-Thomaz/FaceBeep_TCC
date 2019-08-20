using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class FotoDoParticipanteFilterCustomExtension
    {

        public static IQueryable<FotoDoParticipante> WithCustomFilters(this IQueryable<FotoDoParticipante> queryBase, FotoDoParticipanteFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<FotoDoParticipante> WithLimitTenant(this IQueryable<FotoDoParticipante> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

