﻿using Common.Domain.Base;
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
    public class ParticipanteApplicationServiceBase : ApplicationServiceBase<Participante, ParticipanteDto, ParticipanteFilter>, IParticipanteApplicationService
    {
        protected readonly ValidatorAnnotations<ParticipanteDto> _validatorAnnotations;
        protected readonly IParticipanteService _service;
		protected readonly CurrentUser _user;

        public ParticipanteApplicationServiceBase(IParticipanteService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("Participante");
            this._validatorAnnotations = new ValidatorAnnotations<ParticipanteDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<Participante> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as ParticipanteDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<Participante>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<Participante>();
			foreach (var dto in dtos)
			{
				var _dto = dto as ParticipanteDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<Participante> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as ParticipanteDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
