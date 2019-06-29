using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class StatusUserFilterCustomExtension
    {

        public static IQueryable<StatusUser> WithCustomFilters(this IQueryable<StatusUser> queryBase, StatusUserFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<StatusUser> WithLimitTenant(this IQueryable<StatusUser> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

