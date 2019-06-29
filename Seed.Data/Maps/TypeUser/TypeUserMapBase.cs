using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class TypeUserMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<TypeUser> type);

        public TypeUserMapBase(EntityTypeBuilder<TypeUser> type)
        {
            
            type.ToTable("TypeUser");
            type.Property(t => t.TypeUserId).HasColumnName("TypeUserId");
           

            type.Property(t => t.Description).HasColumnName("Description").HasColumnType("nchar(300)");


            type.HasKey(d => new { d.TypeUserId, }); 

			CustomConfig(type);
        }
		
    }
}