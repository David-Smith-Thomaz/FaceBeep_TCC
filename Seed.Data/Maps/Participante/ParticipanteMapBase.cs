using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class ParticipanteMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Participante> type);

        public ParticipanteMapBase(EntityTypeBuilder<Participante> type)
        {
            
            type.ToTable("Participante");
            type.Property(t => t.ParticipanteId).HasColumnName("ParticipanteId");
           

            type.Property(t => t.UsuarioId).HasColumnName("UsuarioId");
            type.Property(t => t.CodigoADM).HasColumnName("CodigoADM");
            type.Property(t => t.Apelido).HasColumnName("Apelido").HasColumnType("varchar(50)");
            type.Property(t => t.TipoDeParticipanteId).HasColumnName("TipoDeParticipanteId");
            type.Property(t => t.NomeCompleto).HasColumnName("NomeCompleto").HasColumnType("varchar(150)");
            type.Property(t => t.DataDenascimento).HasColumnName("DataDenascimento");
            type.Property(t => t.Endereco).HasColumnName("Endereco").HasColumnType("varchar(150)");
            type.Property(t => t.Bairro).HasColumnName("Bairro").HasColumnType("varchar(150)");
            type.Property(t => t.NumeroCasa).HasColumnName("NumeroCasa");
            type.Property(t => t.Cep).HasColumnName("Cep").HasColumnType("varchar(50)");
            type.Property(t => t.FotoDoParticipanteId).HasColumnName("FotoDoParticipanteId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");


            type.HasKey(d => new { d.ParticipanteId, }); 

			CustomConfig(type);
        }
		
    }
}