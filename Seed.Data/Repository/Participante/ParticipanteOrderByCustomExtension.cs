using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class ParticipanteOrderCustomExtension
    {

        public static IQueryable<Participante> OrderByDomain(this IQueryable<Participante> queryBase, ParticipanteFilter filters)
        {
            return queryBase.OrderBy(_ => _.ParticipanteId);
        }

    }
}

