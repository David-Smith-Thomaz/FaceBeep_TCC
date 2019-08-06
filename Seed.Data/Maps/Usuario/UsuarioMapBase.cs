using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class UsuarioMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Usuario> type);

        public UsuarioMapBase(EntityTypeBuilder<Usuario> type)
        {
            
            type.ToTable("Usuario");
            type.Property(t => t.UsuarioId).HasColumnName("UsuarioId");
           

            type.Property(t => t.Login).HasColumnName("Login").HasColumnType("varchar(50)");
            type.Property(t => t.Senha).HasColumnName("Senha").HasColumnType("varchar(50)");
            type.Property(t => t.Email).HasColumnName("Email").HasColumnType("varchar(50)");
            type.Property(t => t.StatusDoUsuarioId).HasColumnName("StatusDoUsuarioId");
            type.Property(t => t.TipoDeUsuarioId).HasColumnName("TipoDeUsuarioId");
            type.Property(t => t.ParticipanteId).HasColumnName("ParticipanteId");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.UsuarioId, }); 

			CustomConfig(type);
        }
		
    }
}