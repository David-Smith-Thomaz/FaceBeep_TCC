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
    public class StatusDoUsuarioApplicationServiceBase : ApplicationServiceBase<StatusDoUsuario, StatusDoUsuarioDto, StatusDoUsuarioFilter>, IStatusDoUsuarioApplicationService
    {
        protected readonly ValidatorAnnotations<StatusDoUsuarioDto> _validatorAnnotations;
        protected readonly IStatusDoUsuarioService _service;
		protected readonly CurrentUser _user;

        public StatusDoUsuarioApplicationServiceBase(IStatusDoUsuarioService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("StatusDoUsuario");
            this._validatorAnnotations = new ValidatorAnnotations<StatusDoUsuarioDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<StatusDoUsuario> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as StatusDoUsuarioDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<StatusDoUsuario>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<StatusDoUsuario>();
			foreach (var dto in dtos)
			{
				var _dto = dto as StatusDoUsuarioDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<StatusDoUsuario> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as StatusDoUsuarioDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
