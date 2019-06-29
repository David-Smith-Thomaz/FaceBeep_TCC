using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class RegisterIsSuitableValidation : ValidatorSpecification<Register>
    {
        public RegisterIsSuitableValidation(IRegisterRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Register>(Instance of is suitable,"message for user"));
        }

    }
}
