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
    public class GroupParticipantApplicationServiceBase : ApplicationServiceBase<GroupParticipant, GroupParticipantDto, GroupParticipantFilter>, IGroupParticipantApplicationService
    {
        protected readonly ValidatorAnnotations<GroupParticipantDto> _validatorAnnotations;
        protected readonly IGroupParticipantService _service;
		protected readonly CurrentUser _user;

        public GroupParticipantApplicationServiceBase(IGroupParticipantService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("GroupParticipant");
            this._validatorAnnotations = new ValidatorAnnotations<GroupParticipantDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<GroupParticipant> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as GroupParticipantDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<GroupParticipant>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<GroupParticipant>();
			foreach (var dto in dtos)
			{
				var _dto = dto as GroupParticipantDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<GroupParticipant> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as GroupParticipantDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
