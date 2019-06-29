using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class StatusUserIsConsistentValidation : ValidatorSpecification<StatusUser>
    {
        public StatusUserIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusUser>(Instance of is consistent specification,"message for user"));
        }

    }
}
