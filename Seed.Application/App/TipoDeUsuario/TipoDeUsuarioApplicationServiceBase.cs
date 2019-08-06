using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Dto;
using Seed.Application.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Services;
using Seed.Dto;
using System.Threading.Tasks;
using Common.Domain.Model;
using System.Collections.Generic;

namespace Seed.Application
{
    public class TipoDeUsuarioApplicationServiceBase : ApplicationServiceBase<TipoDeUsuario, TipoDeUsuarioDto, TipoDeUsuarioFilter>, ITipoDeUsuarioApplicationService
    {
        protected readonly ValidatorAnnotations<TipoDeUsuarioDto> _validatorAnnotations;
        protected readonly ITipoDeUsuarioService _service;
		protected readonly CurrentUser _user;

        public TipoDeUsuarioApplicationServiceBase(ITipoDeUsuarioService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("TipoDeUsuario");
            this._validatorAnnotations = new ValidatorAnnotations<TipoDeUsuarioDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<TipoDeUsuario> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as TipoDeUsuarioDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<TipoDeUsuario>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<TipoDeUsuario>();
			foreach (var dto in dtos)
			{
				var _dto = dto as TipoDeUsuarioDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<TipoDeUsuario> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as TipoDeUsuarioDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
