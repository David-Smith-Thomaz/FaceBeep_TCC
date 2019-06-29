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
    public class TypeUserApplicationService : TypeUserApplicationServiceBase
    {

        public TypeUserApplicationService(ITypeUserService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache, user)
        {
  
        }

        protected override System.Collections.Generic.IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<TypeUser> dataList)
        {
            return base.MapperDomainToResult<TypeUserDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }


    }
}
