using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class ParticipantMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Participant> type);

        public ParticipantMapBase(EntityTypeBuilder<Participant> type)
        {
            
            type.ToTable("Participant");
            type.Property(t => t.ParticipantId).HasColumnName("ParticipantId");
           

            type.Property(t => t.UserId).HasColumnName("UserId");
            type.Property(t => t.GroupParticipantId).HasColumnName("GroupParticipantId");
            type.Property(t => t.PhotoPerfil).HasColumnName("PhotoPerfil").HasColumnType("varchar(150)");
            type.Property(t => t.Name).HasColumnName("Name").HasColumnType("varchar(50)");
            type.Property(t => t.Description).HasColumnName("Description").HasColumnType("varchar(300)");
            type.Property(t => t.DocumentNumber).HasColumnName("DocumentNumber");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.ParticipantId, }); 

			CustomConfig(type);
        }
		
    }
}