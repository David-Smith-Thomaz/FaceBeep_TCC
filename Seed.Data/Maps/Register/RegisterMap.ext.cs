using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class RegisterMap : RegisterMapBase
    {
        public RegisterMap(EntityTypeBuilder<Register> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Register> type)
        {

        }

    }
}