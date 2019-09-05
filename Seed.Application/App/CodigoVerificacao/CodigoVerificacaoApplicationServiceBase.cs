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
    public class CodigoVerificacaoApplicationServiceBase : ApplicationServiceBase<CodigoVerificacao, CodigoVerificacaoDto, CodigoVerificacaoFilter>, ICodigoVerificacaoApplicationService
    {
        protected readonly ValidatorAnnotations<CodigoVerificacaoDto> _validatorAnnotations;
        protected readonly ICodigoVerificacaoService _service;
		protected readonly CurrentUser _user;

        public CodigoVerificacaoApplicationServiceBase(ICodigoVerificacaoService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("CodigoVerificacao");
            this._validatorAnnotations = new ValidatorAnnotations<CodigoVerificacaoDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<CodigoVerificacao> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as CodigoVerificacaoDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<CodigoVerificacao>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<CodigoVerificacao>();
			foreach (var dto in dtos)
			{
				var _dto = dto as CodigoVerificacaoDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<CodigoVerificacao> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as CodigoVerificacaoDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
