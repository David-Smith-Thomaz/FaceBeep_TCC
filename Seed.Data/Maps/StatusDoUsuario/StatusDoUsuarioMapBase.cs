using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class StatusDoUsuarioMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<StatusDoUsuario> type);

        public StatusDoUsuarioMapBase(EntityTypeBuilder<StatusDoUsuario> type)
        {
            
            type.ToTable("StatusDoUsuario");
            type.Property(t => t.StatusDoUsuarioId).HasColumnName("StatusDoUsuarioId");
           

            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(50)");


            type.HasKey(d => new { d.StatusDoUsuarioId, }); 

			CustomConfig(type);
        }
		
    }
}