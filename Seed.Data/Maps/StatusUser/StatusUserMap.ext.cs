using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class StatusUserMap : StatusUserMapBase
    {
        public StatusUserMap(EntityTypeBuilder<StatusUser> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<StatusUser> type)
        {

        }

    }
}