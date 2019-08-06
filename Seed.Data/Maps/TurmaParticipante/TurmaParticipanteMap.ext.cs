using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class TurmaParticipanteMap : TurmaParticipanteMapBase
    {
        public TurmaParticipanteMap(EntityTypeBuilder<TurmaParticipante> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<TurmaParticipante> type)
        {

        }

    }
}