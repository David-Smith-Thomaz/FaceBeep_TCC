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
    public class TurmaParticipanteApplicationServiceBase : ApplicationServiceBase<TurmaParticipante, TurmaParticipanteDto, TurmaParticipanteFilter>, ITurmaParticipanteApplicationService
    {
        protected readonly ValidatorAnnotations<TurmaParticipanteDto> _validatorAnnotations;
        protected readonly ITurmaParticipanteService _service;
		protected readonly CurrentUser _user;

        public TurmaParticipanteApplicationServiceBase(ITurmaParticipanteService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("TurmaParticipante");
            this._validatorAnnotations = new ValidatorAnnotations<TurmaParticipanteDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<TurmaParticipante> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as TurmaParticipanteDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<TurmaParticipante>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<TurmaParticipante>();
			foreach (var dto in dtos)
			{
				var _dto = dto as TurmaParticipanteDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<TurmaParticipante> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as TurmaParticipanteDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
