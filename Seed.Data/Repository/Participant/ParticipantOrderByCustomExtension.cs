using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class ParticipantOrderCustomExtension
    {

        public static IQueryable<Participant> OrderByDomain(this IQueryable<Participant> queryBase, ParticipantFilter filters)
        {
            return queryBase.OrderBy(_ => _.ParticipantId);
        }

    }
}

