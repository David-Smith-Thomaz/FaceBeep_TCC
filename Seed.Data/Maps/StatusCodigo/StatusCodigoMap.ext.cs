using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class StatusCodigoMap : StatusCodigoMapBase
    {
        public StatusCodigoMap(EntityTypeBuilder<StatusCodigo> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<StatusCodigo> type)
        {

        }

    }
}