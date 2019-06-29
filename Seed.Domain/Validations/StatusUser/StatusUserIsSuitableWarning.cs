using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class StatusUserIsSuitableWarning : WarningSpecification<StatusUser>
    {
        public StatusUserIsSuitableWarning(IStatusUserRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusUser>(Instance of suitable warning specification,"message for user"));
        }

    }
}
