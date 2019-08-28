using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class FotoDoParticipanteMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<FotoDoParticipante> type);

        public FotoDoParticipanteMapBase(EntityTypeBuilder<FotoDoParticipante> type)
        {
            
            type.ToTable("FotoDoParticipante");
            type.Property(t => t.FotoDoParticipateId).HasColumnName("FotoDoParticipateId");
           

            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(150)");
            type.Property(t => t.Arquivo).HasColumnName("Arquivo").HasColumnType("varchar(max)");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");


            type.HasKey(d => new { d.FotoDoParticipateId, }); 

			CustomConfig(type);
        }
		
    }
}