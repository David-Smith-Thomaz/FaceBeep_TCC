using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class StatusUserMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<StatusUser> type);

        public StatusUserMapBase(EntityTypeBuilder<StatusUser> type)
        {
            
            type.ToTable("StatusUser");
            type.Property(t => t.StatusUserId).HasColumnName("StatusUserId");
           

            type.Property(t => t.Description).HasColumnName("Description").HasColumnType("varchar(50)");


            type.HasKey(d => new { d.StatusUserId, }); 

			CustomConfig(type);
        }
		
    }
}