using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class StatusUserOrderCustomExtension
    {

        public static IQueryable<StatusUser> OrderByDomain(this IQueryable<StatusUser> queryBase, StatusUserFilter filters)
        {
            return queryBase.OrderBy(_ => _.StatusUserId);
        }

    }
}

