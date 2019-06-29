using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class ParticipantMap : ParticipantMapBase
    {
        public ParticipantMap(EntityTypeBuilder<Participant> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Participant> type)
        {

        }

    }
}