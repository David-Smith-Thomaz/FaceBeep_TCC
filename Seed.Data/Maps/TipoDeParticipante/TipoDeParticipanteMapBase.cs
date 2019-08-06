using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class TipoDeParticipanteMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<TipoDeParticipante> type);

        public TipoDeParticipanteMapBase(EntityTypeBuilder<TipoDeParticipante> type)
        {
            
            type.ToTable("TipoDeParticipante");
            type.Property(t => t.TipoDeParticipanteId).HasColumnName("TipoDeParticipanteId");
           

            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(50)");


            type.HasKey(d => new { d.TipoDeParticipanteId, }); 

			CustomConfig(type);
        }
		
    }
}