using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class TurmaMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Turma> type);

        public TurmaMapBase(EntityTypeBuilder<Turma> type)
        {
            
            type.ToTable("Turma");
            type.Property(t => t.TurmaId).HasColumnName("TurmaId");
           

            type.Property(t => t.CodigoDaTurma).HasColumnName("CodigoDaTurma").HasColumnType("varchar(150)");
            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(150)");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(max)");
            type.Property(t => t.DataInicio).HasColumnName("DataInicio");
            type.Property(t => t.DataFim).HasColumnName("DataFim");
            type.Property(t => t.AdmTurmaId).HasColumnName("AdmTurmaId");
            type.Property(t => t.StatusDaTurmaId).HasColumnName("StatusDaTurmaId");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");


            type.HasKey(d => new { d.TurmaId, }); 

			CustomConfig(type);
        }
		
    }
}