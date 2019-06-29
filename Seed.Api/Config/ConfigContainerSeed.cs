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
            
			services.AddScoped<IParticipantApplicationService, ParticipantApplicationService>();
			services.AddScoped<IParticipantService, ParticipantService>();
			services.AddScoped<IParticipantRepository, ParticipantRepository>();

			services.AddScoped<IUserApplicationService, UserApplicationService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IUserRepository, UserRepository>();

			services.AddScoped<IStatusUserApplicationService, StatusUserApplicationService>();
			services.AddScoped<IStatusUserService, StatusUserService>();
			services.AddScoped<IStatusUserRepository, StatusUserRepository>();

			services.AddScoped<ITypeUserApplicationService, TypeUserApplicationService>();
			services.AddScoped<ITypeUserService, TypeUserService>();
			services.AddScoped<ITypeUserRepository, TypeUserRepository>();

			services.AddScoped<IGroupParticipantApplicationService, GroupParticipantApplicationService>();
			services.AddScoped<IGroupParticipantService, GroupParticipantService>();
			services.AddScoped<IGroupParticipantRepository, GroupParticipantRepository>();

			services.AddScoped<IRegisterApplicationService, RegisterApplicationService>();
			services.AddScoped<IRegisterService, RegisterService>();
			services.AddScoped<IRegisterRepository, RegisterRepository>();

			services.AddScoped<IStatusRegisterApplicationService, StatusRegisterApplicationService>();
			services.AddScoped<IStatusRegisterService, StatusRegisterService>();
			services.AddScoped<IStatusRegisterRepository, StatusRegisterRepository>();



            RegisterOtherComponents(services);
        }
    }
}
