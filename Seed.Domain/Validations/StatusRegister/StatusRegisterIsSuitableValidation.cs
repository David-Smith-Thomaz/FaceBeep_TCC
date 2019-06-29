using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class StatusRegisterIsSuitableValidation : ValidatorSpecification<StatusRegister>
    {
        public StatusRegisterIsSuitableValidation(IStatusRegisterRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusRegister>(Instance of is suitable,"message for user"));
        }

    }
}
