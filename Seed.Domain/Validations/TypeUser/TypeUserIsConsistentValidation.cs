using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class TypeUserIsConsistentValidation : ValidatorSpecification<TypeUser>
    {
        public TypeUserIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TypeUser>(Instance of is consistent specification,"message for user"));
        }

    }
}
