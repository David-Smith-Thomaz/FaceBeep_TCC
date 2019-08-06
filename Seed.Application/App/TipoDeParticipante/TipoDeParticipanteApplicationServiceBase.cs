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
    public class TipoDeParticipanteApplicationServiceBase : ApplicationServiceBase<TipoDeParticipante, TipoDeParticipanteDto, TipoDeParticipanteFilter>, ITipoDeParticipanteApplicationService
    {
        protected readonly ValidatorAnnotations<TipoDeParticipanteDto> _validatorAnnotations;
        protected readonly ITipoDeParticipanteService _service;
		protected readonly CurrentUser _user;

        public TipoDeParticipanteApplicationServiceBase(ITipoDeParticipanteService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("TipoDeParticipante");
            this._validatorAnnotations = new ValidatorAnnotations<TipoDeParticipanteDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<TipoDeParticipante> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as TipoDeParticipanteDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<TipoDeParticipante>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<TipoDeParticipante>();
			foreach (var dto in dtos)
			{
				var _dto = dto as TipoDeParticipanteDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<TipoDeParticipante> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as TipoDeParticipanteDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
