using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class RegisterMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Register> type);

        public RegisterMapBase(EntityTypeBuilder<Register> type)
        {
            
            type.ToTable("Register");
            type.Property(t => t.RegisterId).HasColumnName("RegisterId");
           

            type.Property(t => t.StatusRegisterId).HasColumnName("StatusRegisterId");
            type.Property(t => t.ParticipantId).HasColumnName("ParticipantId");
            type.Property(t => t.Description).HasColumnName("Description").HasColumnType("varchar(max)");
            type.Property(t => t.EnterDate).HasColumnName("EnterDate");
            type.Property(t => t.ExitDate).HasColumnName("ExitDate");


            type.HasKey(d => new { d.RegisterId, }); 

			CustomConfig(type);
        }
		
    }
}