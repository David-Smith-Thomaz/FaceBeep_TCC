using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class StatusDoUsuarioMap : StatusDoUsuarioMapBase
    {
        public StatusDoUsuarioMap(EntityTypeBuilder<StatusDoUsuario> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<StatusDoUsuario> type)
        {

        }

    }
}