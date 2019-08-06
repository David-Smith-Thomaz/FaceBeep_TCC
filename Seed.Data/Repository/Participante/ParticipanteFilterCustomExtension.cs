using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class ParticipanteFilterCustomExtension
    {

        public static IQueryable<Participante> WithCustomFilters(this IQueryable<Participante> queryBase, ParticipanteFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<Participante> WithLimitTenant(this IQueryable<Participante> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

