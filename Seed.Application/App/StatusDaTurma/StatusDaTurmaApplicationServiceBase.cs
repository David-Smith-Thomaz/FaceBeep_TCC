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
    public class StatusDaTurmaApplicationServiceBase : ApplicationServiceBase<StatusDaTurma, StatusDaTurmaDto, StatusDaTurmaFilter>, IStatusDaTurmaApplicationService
    {
        protected readonly ValidatorAnnotations<StatusDaTurmaDto> _validatorAnnotations;
        protected readonly IStatusDaTurmaService _service;
		protected readonly CurrentUser _user;

        public StatusDaTurmaApplicationServiceBase(IStatusDaTurmaService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("StatusDaTurma");
            this._validatorAnnotations = new ValidatorAnnotations<StatusDaTurmaDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<StatusDaTurma> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as StatusDaTurmaDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<StatusDaTurma>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<StatusDaTurma>();
			foreach (var dto in dtos)
			{
				var _dto = dto as StatusDaTurmaDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<StatusDaTurma> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as StatusDaTurmaDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
