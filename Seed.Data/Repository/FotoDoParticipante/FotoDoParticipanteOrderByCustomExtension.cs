using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class FotoDoParticipanteOrderCustomExtension
    {

        public static IQueryable<FotoDoParticipante> OrderByDomain(this IQueryable<FotoDoParticipante> queryBase, FotoDoParticipanteFilter filters)
        {
            return queryBase.OrderBy(_ => _.FotoDoParticipateId);
        }

    }
}

