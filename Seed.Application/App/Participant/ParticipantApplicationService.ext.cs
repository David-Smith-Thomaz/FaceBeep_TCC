using Common.Domain.Interfaces;
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
    public class ParticipantApplicationService : ParticipantApplicationServiceBase
    {

        public ParticipantApplicationService(IParticipantService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache, user)
        {
  
        }

        protected override System.Collections.Generic.IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<Participant> dataList)
        {
            return base.MapperDomainToResult<ParticipantDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }


    }
}
