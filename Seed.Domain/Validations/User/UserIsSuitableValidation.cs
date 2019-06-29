using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class UserIsSuitableValidation : ValidatorSpecification<User>
    {
        public UserIsSuitableValidation(IUserRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<User>(Instance of is suitable,"message for user"));
        }

    }
}
