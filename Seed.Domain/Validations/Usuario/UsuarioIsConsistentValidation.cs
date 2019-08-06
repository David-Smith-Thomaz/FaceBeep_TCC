using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class UsuarioIsConsistentValidation : ValidatorSpecification<Usuario>
    {
        public UsuarioIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Usuario>(Instance of is consistent specification,"message for user"));
        }

    }
}
