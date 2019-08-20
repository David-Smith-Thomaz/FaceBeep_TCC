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
            new StatusDoUsuarioMap(modelBuilder.Entity<StatusDoUsuario>());
            new UsuarioMap(modelBuilder.Entity<Usuario>());
            new TipoDeUsuarioMap(modelBuilder.Entity<TipoDeUsuario>());
            new ParticipanteMap(modelBuilder.Entity<Participante>());
            new TipoDeParticipanteMap(modelBuilder.Entity<TipoDeParticipante>());
            new TurmaMap(modelBuilder.Entity<Turma>());
            new StatusDaTurmaMap(modelBuilder.Entity<StatusDaTurma>());
            new TurmaParticipanteMap(modelBuilder.Entity<TurmaParticipante>());
            new FotoDoParticipanteMap(modelBuilder.Entity<FotoDoParticipante>());

        }


    }
}
