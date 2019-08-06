using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class StatusDaTurmaMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<StatusDaTurma> type);

        public StatusDaTurmaMapBase(EntityTypeBuilder<StatusDaTurma> type)
        {
            
            type.ToTable("StatusDaTurma");
            type.Property(t => t.StatusDaTurmaId).HasColumnName("StatusDaTurmaId");
           

            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(50)");


            type.HasKey(d => new { d.StatusDaTurmaId, }); 

			CustomConfig(type);
        }
		
    }
}