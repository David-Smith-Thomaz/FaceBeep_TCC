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
    public class StatusUserApplicationServiceBase : ApplicationServiceBase<StatusUser, StatusUserDto, StatusUserFilter>, IStatusUserApplicationService
    {
        protected readonly ValidatorAnnotations<StatusUserDto> _validatorAnnotations;
        protected readonly IStatusUserService _service;
		protected readonly CurrentUser _user;

        public StatusUserApplicationServiceBase(IStatusUserService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("StatusUser");
            this._validatorAnnotations = new ValidatorAnnotations<StatusUserDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<StatusUser> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as StatusUserDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<StatusUser>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<StatusUser>();
			foreach (var dto in dtos)
			{
				var _dto = dto as StatusUserDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<StatusUser> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as StatusUserDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
