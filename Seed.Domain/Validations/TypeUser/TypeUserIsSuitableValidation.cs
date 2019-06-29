using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class TypeUserIsSuitableValidation : ValidatorSpecification<TypeUser>
    {
        public TypeUserIsSuitableValidation(ITypeUserRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TypeUser>(Instance of is suitable,"message for user"));
        }

    }
}
