using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class TypeUserOrderCustomExtension
    {

        public static IQueryable<TypeUser> OrderByDomain(this IQueryable<TypeUser> queryBase, TypeUserFilter filters)
        {
            return queryBase.OrderBy(_ => _.TypeUserId);
        }

    }
}

