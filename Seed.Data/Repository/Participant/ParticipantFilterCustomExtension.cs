using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class ParticipantFilterCustomExtension
    {

        public static IQueryable<Participant> WithCustomFilters(this IQueryable<Participant> queryBase, ParticipantFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<Participant> WithLimitTenant(this IQueryable<Participant> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

