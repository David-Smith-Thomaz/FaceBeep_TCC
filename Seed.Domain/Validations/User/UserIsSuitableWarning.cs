using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class UserIsSuitableWarning : WarningSpecification<User>
    {
        public UserIsSuitableWarning(IUserRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<User>(Instance of suitable warning specification,"message for user"));
        }

    }
}
