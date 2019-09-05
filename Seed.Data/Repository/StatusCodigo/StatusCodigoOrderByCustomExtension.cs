using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class StatusCodigoOrderCustomExtension
    {

        public static IQueryable<StatusCodigo> OrderByDomain(this IQueryable<StatusCodigo> queryBase, StatusCodigoFilter filters)
        {
            return queryBase.OrderBy(_ => _.StatusCodigoId);
        }

    }
}

