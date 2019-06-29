using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class StatusRegisterMap : StatusRegisterMapBase
    {
        public StatusRegisterMap(EntityTypeBuilder<StatusRegister> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<StatusRegister> type)
        {

        }

    }
}