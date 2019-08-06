using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class TipoDeUsuarioMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<TipoDeUsuario> type);

        public TipoDeUsuarioMapBase(EntityTypeBuilder<TipoDeUsuario> type)
        {
            
            type.ToTable("TipoDeUsuario");
            type.Property(t => t.TipoDeUsuarioId).HasColumnName("TipoDeUsuarioId");
           

            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(50)");


            type.HasKey(d => new { d.TipoDeUsuarioId, }); 

			CustomConfig(type);
        }
		
    }
}