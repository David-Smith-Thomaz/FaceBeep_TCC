using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class CodigoVerificacaoMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<CodigoVerificacao> type);

        public CodigoVerificacaoMapBase(EntityTypeBuilder<CodigoVerificacao> type)
        {
            
            type.ToTable("CodigoVerificacao");
            type.Property(t => t.CodigoVerificacaoId).HasColumnName("CodigoVerificacaoId");
           

            type.Property(t => t.ParticipanteId).HasColumnName("ParticipanteId");
            type.Property(t => t.Codigo).HasColumnName("Codigo");
            type.Property(t => t.DataInicio).HasColumnName("DataInicio");
            type.Property(t => t.DataFim).HasColumnName("DataFim");
            type.Property(t => t.statusCodigoId).HasColumnName("statusCodigoId");


            type.HasKey(d => new { d.CodigoVerificacaoId, }); 

			CustomConfig(type);
        }
		
    }
}