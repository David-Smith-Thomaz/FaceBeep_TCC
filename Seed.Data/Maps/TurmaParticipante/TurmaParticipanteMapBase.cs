using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class TurmaParticipanteMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<TurmaParticipante> type);

        public TurmaParticipanteMapBase(EntityTypeBuilder<TurmaParticipante> type)
        {
            
            type.ToTable("TurmaParticipante");
            type.Property(t => t.TurmaParticipanteId).HasColumnName("TurmaParticipanteId");
           

            type.Property(t => t.ParticipanteId).HasColumnName("ParticipanteId");
            type.Property(t => t.TurmaId).HasColumnName("TurmaId");


            type.HasKey(d => new { d.TurmaParticipanteId, }); 

			CustomConfig(type);
        }
		
    }
}