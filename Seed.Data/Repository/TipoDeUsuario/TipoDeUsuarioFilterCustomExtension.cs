using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class TipoDeUsuarioFilterCustomExtension
    {

        public static IQueryable<TipoDeUsuario> WithCustomFilters(this IQueryable<TipoDeUsuario> queryBase, TipoDeUsuarioFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<TipoDeUsuario> WithLimitTenant(this IQueryable<TipoDeUsuario> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

