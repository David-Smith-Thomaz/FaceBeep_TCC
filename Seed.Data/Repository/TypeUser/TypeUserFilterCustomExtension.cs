using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class TypeUserFilterCustomExtension
    {

        public static IQueryable<TypeUser> WithCustomFilters(this IQueryable<TypeUser> queryBase, TypeUserFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<TypeUser> WithLimitTenant(this IQueryable<TypeUser> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

