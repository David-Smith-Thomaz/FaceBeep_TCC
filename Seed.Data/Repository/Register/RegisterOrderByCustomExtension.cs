using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class RegisterOrderCustomExtension
    {

        public static IQueryable<Register> OrderByDomain(this IQueryable<Register> queryBase, RegisterFilter filters)
        {
            return queryBase;
        }

    }
}

