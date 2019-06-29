using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class UserMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<User> type);

        public UserMapBase(EntityTypeBuilder<User> type)
        {
            
            type.ToTable("User");
            type.Property(t => t.UserId).HasColumnName("UserId");
           

            type.Property(t => t.StatusUserId).HasColumnName("StatusUserId");
            type.Property(t => t.TypeUserId).HasColumnName("TypeUserId");
            type.Property(t => t.Login).HasColumnName("Login").HasColumnType("varchar(50)");
            type.Property(t => t.Password).HasColumnName("Password").HasColumnType("varchar(150)");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.UserId, }); 

			CustomConfig(type);
        }
		
    }
}