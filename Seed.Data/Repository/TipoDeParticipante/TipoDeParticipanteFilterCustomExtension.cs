using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class TipoDeParticipanteFilterCustomExtension
    {

        public static IQueryable<TipoDeParticipante> WithCustomFilters(this IQueryable<TipoDeParticipante> queryBase, TipoDeParticipanteFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<TipoDeParticipante> WithLimitTenant(this IQueryable<TipoDeParticipante> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

