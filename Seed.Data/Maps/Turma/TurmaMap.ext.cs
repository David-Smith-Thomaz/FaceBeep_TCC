using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class TurmaMap : TurmaMapBase
    {
        public TurmaMap(EntityTypeBuilder<Turma> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Turma> type)
        {

        }

    }
}