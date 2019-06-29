using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class StatusRegisterMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<StatusRegister> type);

        public StatusRegisterMapBase(EntityTypeBuilder<StatusRegister> type)
        {
            
            type.ToTable("StatusRegister");
            type.Property(t => t.StatusRegisterId).HasColumnName("StatusRegisterId");
           

            type.Property(t => t.Description).HasColumnName("Description").HasColumnType("varchar(50)");


            type.HasKey(d => new { d.StatusRegisterId, }); 

			CustomConfig(type);
        }
		
    }
}