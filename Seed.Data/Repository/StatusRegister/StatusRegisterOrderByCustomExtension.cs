using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class StatusRegisterOrderCustomExtension
    {

        public static IQueryable<StatusRegister> OrderByDomain(this IQueryable<StatusRegister> queryBase, StatusRegisterFilter filters)
        {
            return queryBase.OrderBy(_ => _.StatusRegisterId);
        }

    }
}

