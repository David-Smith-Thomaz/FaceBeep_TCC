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
    public class StatusCodigoApplicationServiceBase : ApplicationServiceBase<StatusCodigo, StatusCodigoDto, StatusCodigoFilter>, IStatusCodigoApplicationService
    {
        protected readonly ValidatorAnnotations<StatusCodigoDto> _validatorAnnotations;
        protected readonly IStatusCodigoService _service;
		protected readonly CurrentUser _user;

        public StatusCodigoApplicationServiceBase(IStatusCodigoService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("StatusCodigo");
            this._validatorAnnotations = new ValidatorAnnotations<StatusCodigoDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<StatusCodigo> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as StatusCodigoDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<StatusCodigo>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<StatusCodigo>();
			foreach (var dto in dtos)
			{
				var _dto = dto as StatusCodigoDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<StatusCodigo> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as StatusCodigoDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
