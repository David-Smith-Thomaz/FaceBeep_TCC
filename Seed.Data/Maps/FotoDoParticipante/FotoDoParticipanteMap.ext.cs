using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class FotoDoParticipanteMap : FotoDoParticipanteMapBase
    {
        public FotoDoParticipanteMap(EntityTypeBuilder<FotoDoParticipante> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<FotoDoParticipante> type)
        {

        }

    }
}