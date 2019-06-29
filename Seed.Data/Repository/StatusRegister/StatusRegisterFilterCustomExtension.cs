using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class StatusRegisterFilterCustomExtension
    {

        public static IQueryable<StatusRegister> WithCustomFilters(this IQueryable<StatusRegister> queryBase, StatusRegisterFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<StatusRegister> WithLimitTenant(this IQueryable<StatusRegister> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

