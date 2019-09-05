using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class CodigoVerificacaoMap : CodigoVerificacaoMapBase
    {
        public CodigoVerificacaoMap(EntityTypeBuilder<CodigoVerificacao> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<CodigoVerificacao> type)
        {

        }

    }
}