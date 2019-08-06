using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class UsuarioOrderCustomExtension
    {

        public static IQueryable<Usuario> OrderByDomain(this IQueryable<Usuario> queryBase, UsuarioFilter filters)
        {
            return queryBase.OrderBy(_ => _.UsuarioId);
        }

    }
}

