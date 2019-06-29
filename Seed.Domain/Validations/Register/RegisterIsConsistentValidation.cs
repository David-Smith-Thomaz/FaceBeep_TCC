using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class RegisterIsConsistentValidation : ValidatorSpecification<Register>
    {
        public RegisterIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Register>(Instance of is consistent specification,"message for user"));
        }

    }
}
