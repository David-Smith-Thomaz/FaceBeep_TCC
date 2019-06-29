using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class TypeUserIsSuitableWarning : WarningSpecification<TypeUser>
    {
        public TypeUserIsSuitableWarning(ITypeUserRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TypeUser>(Instance of suitable warning specification,"message for user"));
        }

    }
}
