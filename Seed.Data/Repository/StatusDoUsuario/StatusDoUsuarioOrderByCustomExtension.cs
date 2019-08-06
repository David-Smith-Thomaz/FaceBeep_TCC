using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class StatusDoUsuarioOrderCustomExtension
    {

        public static IQueryable<StatusDoUsuario> OrderByDomain(this IQueryable<StatusDoUsuario> queryBase, StatusDoUsuarioFilter filters)
        {
            return queryBase.OrderBy(_ => _.StatusDoUsuarioId);
        }

    }
}

