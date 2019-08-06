using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class TipoDeUsuarioMap : TipoDeUsuarioMapBase
    {
        public TipoDeUsuarioMap(EntityTypeBuilder<TipoDeUsuario> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<TipoDeUsuario> type)
        {

        }

    }
}