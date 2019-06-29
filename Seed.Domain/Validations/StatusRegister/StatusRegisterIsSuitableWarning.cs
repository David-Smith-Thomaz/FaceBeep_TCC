using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class StatusRegisterIsSuitableWarning : WarningSpecification<StatusRegister>
    {
        public StatusRegisterIsSuitableWarning(IStatusRegisterRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusRegister>(Instance of suitable warning specification,"message for user"));
        }

    }
}
