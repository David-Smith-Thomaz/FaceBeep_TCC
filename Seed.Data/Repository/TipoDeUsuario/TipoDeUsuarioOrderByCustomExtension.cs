using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class TipoDeUsuarioOrderCustomExtension
    {

        public static IQueryable<TipoDeUsuario> OrderByDomain(this IQueryable<TipoDeUsuario> queryBase, TipoDeUsuarioFilter filters)
        {
            return queryBase.OrderBy(_ => _.TipoDeUsuarioId);
        }

    }
}

