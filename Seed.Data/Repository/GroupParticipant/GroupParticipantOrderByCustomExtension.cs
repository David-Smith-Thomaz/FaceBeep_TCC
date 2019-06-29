using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class GroupParticipantOrderCustomExtension
    {

        public static IQueryable<GroupParticipant> OrderByDomain(this IQueryable<GroupParticipant> queryBase, GroupParticipantFilter filters)
        {
            return queryBase.OrderBy(_ => _.GroupParticipantId);
        }

    }
}

