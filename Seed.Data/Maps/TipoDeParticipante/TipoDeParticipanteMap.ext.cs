using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class TipoDeParticipanteMap : TipoDeParticipanteMapBase
    {
        public TipoDeParticipanteMap(EntityTypeBuilder<TipoDeParticipante> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<TipoDeParticipante> type)
        {

        }

    }
}