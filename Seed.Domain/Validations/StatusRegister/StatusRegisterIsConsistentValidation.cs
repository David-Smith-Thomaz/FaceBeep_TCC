using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class StatusRegisterIsConsistentValidation : ValidatorSpecification<StatusRegister>
    {
        public StatusRegisterIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusRegister>(Instance of is consistent specification,"message for user"));
        }

    }
}
