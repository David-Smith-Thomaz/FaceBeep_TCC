﻿using Common.Domain.Interfaces;
using Seed.Application.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Services;
using Seed.Dto;
using System.Linq;
using System.Collections.Generic;
using Common.Domain.Base;
using Common.Domain.Model;

namespace Seed.Application
{
    public class TipoDeParticipanteApplicationService : TipoDeParticipanteApplicationServiceBase
    {

        public TipoDeParticipanteApplicationService(ITipoDeParticipanteService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache, user)
        {
  
        }

        protected override System.Collections.Generic.IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<TipoDeParticipante> dataList)
        {
            return base.MapperDomainToResult<TipoDeParticipanteDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }


    }
}
