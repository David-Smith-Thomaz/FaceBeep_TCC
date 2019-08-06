using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class UsuarioFilterCustomExtension
    {

        public static IQueryable<Usuario> WithCustomFilters(this IQueryable<Usuario> queryBase, UsuarioFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<Usuario> WithLimitTenant(this IQueryable<Usuario> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

