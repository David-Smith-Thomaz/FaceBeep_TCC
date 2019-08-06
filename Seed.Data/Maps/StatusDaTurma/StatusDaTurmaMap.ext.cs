using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class StatusDaTurmaMap : StatusDaTurmaMapBase
    {
        public StatusDaTurmaMap(EntityTypeBuilder<StatusDaTurma> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<StatusDaTurma> type)
        {

        }

    }
}