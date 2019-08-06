using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class UsuarioMap : UsuarioMapBase
    {
        public UsuarioMap(EntityTypeBuilder<Usuario> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Usuario> type)
        {

        }

    }
}