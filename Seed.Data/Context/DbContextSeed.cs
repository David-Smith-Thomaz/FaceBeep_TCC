using Common.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Seed.Data.Map;
using Seed.Domain.Entitys;

namespace Seed.Data.Context
{
    public class DbContextSeed : DbContextMultiTenantcy
    {

        public DbContextSeed(DbContextOptions<DbContextSeed> options, CurrentUser user, IConfiguration config)
            : base(options, user, config)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ParticipantMap(modelBuilder.Entity<Participant>());
            new UserMap(modelBuilder.Entity<User>());
            new StatusUserMap(modelBuilder.Entity<StatusUser>());
            new TypeUserMap(modelBuilder.Entity<TypeUser>());
            new GroupParticipantMap(modelBuilder.Entity<GroupParticipant>());
            new RegisterMap(modelBuilder.Entity<Register>());
            new StatusRegisterMap(modelBuilder.Entity<StatusRegister>());

        }


    }
}
