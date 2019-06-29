using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class GroupParticipantMap : GroupParticipantMapBase
    {
        public GroupParticipantMap(EntityTypeBuilder<GroupParticipant> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<GroupParticipant> type)
        {

        }

    }
}