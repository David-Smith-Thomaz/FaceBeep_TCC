using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class GroupParticipantFilterCustomExtension
    {

        public static IQueryable<GroupParticipant> WithCustomFilters(this IQueryable<GroupParticipant> queryBase, GroupParticipantFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<GroupParticipant> WithLimitTenant(this IQueryable<GroupParticipant> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

