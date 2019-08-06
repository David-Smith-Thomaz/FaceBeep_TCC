using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class TipoDeParticipanteOrderCustomExtension
    {

        public static IQueryable<TipoDeParticipante> OrderByDomain(this IQueryable<TipoDeParticipante> queryBase, TipoDeParticipanteFilter filters)
        {
            return queryBase.OrderBy(_ => _.TipoDeParticipanteId);
        }

    }
}

