using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class UserMap : UserMapBase
    {
        public UserMap(EntityTypeBuilder<User> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<User> type)
        {

        }

    }
}