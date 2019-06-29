using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class RegisterIsSuitableWarning : WarningSpecification<Register>
    {
        public RegisterIsSuitableWarning(IRegisterRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Register>(Instance of suitable warning specification,"message for user"));
        }

    }
}
