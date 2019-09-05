using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class StatusCodigoFilterCustomExtension
    {

        public static IQueryable<StatusCodigo> WithCustomFilters(this IQueryable<StatusCodigo> queryBase, StatusCodigoFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<StatusCodigo> WithLimitTenant(this IQueryable<StatusCodigo> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

