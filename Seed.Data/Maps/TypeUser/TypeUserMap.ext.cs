using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class TypeUserMap : TypeUserMapBase
    {
        public TypeUserMap(EntityTypeBuilder<TypeUser> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<TypeUser> type)
        {

        }

    }
}