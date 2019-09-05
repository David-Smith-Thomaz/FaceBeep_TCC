using Common.Cache;
using Common.Domain.Interfaces;
using Common.Orm;
using Microsoft.Extensions.DependencyInjection;
using Seed.Application;
using Seed.Application.Interfaces;
using Seed.Data.Context;
using Seed.Data.Repository;
using Seed.Domain.Interfaces.Repository;
using Seed.Domain.Interfaces.Services;
using Seed.Domain.Services;

namespace Seed.Api
{
    public static partial class ConfigContainerSeed
    {

        public static void Config(IServiceCollection services)
        {
            services.AddScoped<ICache, RedisComponent>();
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContextSeed>>();
            
			services.AddScoped<IStatusCodigoApplicationService, StatusCodigoApplicationService>();
			services.AddScoped<IStatusCodigoService, StatusCodigoService>();
			services.AddScoped<IStatusCodigoRepository, StatusCodigoRepository>();

			services.AddScoped<ICodigoVerificacaoApplicationService, CodigoVerificacaoApplicationService>();
			services.AddScoped<ICodigoVerificacaoService, CodigoVerificacaoService>();
			services.AddScoped<ICodigoVerificacaoRepository, CodigoVerificacaoRepository>();

			services.AddScoped<IStatusDoUsuarioApplicationService, StatusDoUsuarioApplicationService>();
			services.AddScoped<IStatusDoUsuarioService, StatusDoUsuarioService>();
			services.AddScoped<IStatusDoUsuarioRepository, StatusDoUsuarioRepository>();

			services.AddScoped<IUsuarioApplicationService, UsuarioApplicationService>();
			services.AddScoped<IUsuarioService, UsuarioService>();
			services.AddScoped<IUsuarioRepository, UsuarioRepository>();

			services.AddScoped<ITipoDeUsuarioApplicationService, TipoDeUsuarioApplicationService>();
			services.AddScoped<ITipoDeUsuarioService, TipoDeUsuarioService>();
			services.AddScoped<ITipoDeUsuarioRepository, TipoDeUsuarioRepository>();

			services.AddScoped<IParticipanteApplicationService, ParticipanteApplicationService>();
			services.AddScoped<IParticipanteService, ParticipanteService>();
			services.AddScoped<IParticipanteRepository, ParticipanteRepository>();

			services.AddScoped<ITipoDeParticipanteApplicationService, TipoDeParticipanteApplicationService>();
			services.AddScoped<ITipoDeParticipanteService, TipoDeParticipanteService>();
			services.AddScoped<ITipoDeParticipanteRepository, TipoDeParticipanteRepository>();

			services.AddScoped<ITurmaApplicationService, TurmaApplicationService>();
			services.AddScoped<ITurmaService, TurmaService>();
			services.AddScoped<ITurmaRepository, TurmaRepository>();

			services.AddScoped<IStatusDaTurmaApplicationService, StatusDaTurmaApplicationService>();
			services.AddScoped<IStatusDaTurmaService, StatusDaTurmaService>();
			services.AddScoped<IStatusDaTurmaRepository, StatusDaTurmaRepository>();

			services.AddScoped<ITurmaParticipanteApplicationService, TurmaParticipanteApplicationService>();
			services.AddScoped<ITurmaParticipanteService, TurmaParticipanteService>();
			services.AddScoped<ITurmaParticipanteRepository, TurmaParticipanteRepository>();

			services.AddScoped<IFotoDoParticipanteApplicationService, FotoDoParticipanteApplicationService>();
			services.AddScoped<IFotoDoParticipanteService, FotoDoParticipanteService>();
			services.AddScoped<IFotoDoParticipanteRepository, FotoDoParticipanteRepository>();



            RegisterOtherComponents(services);
        }
    }
}
