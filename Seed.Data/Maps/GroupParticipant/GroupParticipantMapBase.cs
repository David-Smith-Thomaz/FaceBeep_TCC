using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class GroupParticipantMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<GroupParticipant> type);

        public GroupParticipantMapBase(EntityTypeBuilder<GroupParticipant> type)
        {
            
            type.ToTable("GroupParticipant");
            type.Property(t => t.GroupParticipantId).HasColumnName("GroupParticipantId");
           

            type.Property(t => t.GroupName).HasColumnName("GroupName").HasColumnType("nchar(100)");
            type.Property(t => t.StartDatePeriod).HasColumnName("StartDatePeriod");
            type.Property(t => t.EndDatePeriod).HasColumnName("EndDatePeriod");
            type.Property(t => t.Active).HasColumnName("Active");


            type.HasKey(d => new { d.GroupParticipantId, }); 

			CustomConfig(type);
        }
		
    }
}