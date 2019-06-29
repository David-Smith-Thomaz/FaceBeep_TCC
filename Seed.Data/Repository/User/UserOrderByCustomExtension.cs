using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class UserOrderCustomExtension
    {

        public static IQueryable<User> OrderByDomain(this IQueryable<User> queryBase, UserFilter filters)
        {
            return queryBase.OrderBy(_ => _.UserId);
        }

    }
}

