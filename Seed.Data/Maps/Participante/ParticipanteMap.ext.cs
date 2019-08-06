using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class ParticipanteMap : ParticipanteMapBase
    {
        public ParticipanteMap(EntityTypeBuilder<Participante> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Participante> type)
        {

        }

    }
}