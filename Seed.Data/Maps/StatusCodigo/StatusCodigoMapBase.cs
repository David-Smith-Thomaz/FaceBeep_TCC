using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class StatusCodigoMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<StatusCodigo> type);

        public StatusCodigoMapBase(EntityTypeBuilder<StatusCodigo> type)
        {
            
            type.ToTable("StatusCodigo");
            type.Property(t => t.StatusCodigoId).HasColumnName("StatusCodigoId");
           

            type.Property(t => t.Description).HasColumnName("Description").HasColumnType("varchar(50)");


            type.HasKey(d => new { d.StatusCodigoId, }); 

			CustomConfig(type);
        }
		
    }
}