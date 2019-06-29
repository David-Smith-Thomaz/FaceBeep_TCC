using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class StatusUserIsSuitableValidation : ValidatorSpecification<StatusUser>
    {
        public StatusUserIsSuitableValidation(IStatusUserRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusUser>(Instance of is suitable,"message for user"));
        }

    }
}
