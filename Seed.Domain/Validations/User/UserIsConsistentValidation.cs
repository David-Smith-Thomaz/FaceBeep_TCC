using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class UserIsConsistentValidation : ValidatorSpecification<User>
    {
        public UserIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<User>(Instance of is consistent specification,"message for user"));
        }

    }
}
