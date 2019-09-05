using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class CodigoVerificacaoFilterCustomExtension
    {

        public static IQueryable<CodigoVerificacao> WithCustomFilters(this IQueryable<CodigoVerificacao> queryBase, CodigoVerificacaoFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<CodigoVerificacao> WithLimitTenant(this IQueryable<CodigoVerificacao> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

