using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class StatusDoUsuarioFilterCustomExtension
    {

        public static IQueryable<StatusDoUsuario> WithCustomFilters(this IQueryable<StatusDoUsuario> queryBase, StatusDoUsuarioFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<StatusDoUsuario> WithLimitTenant(this IQueryable<StatusDoUsuario> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

