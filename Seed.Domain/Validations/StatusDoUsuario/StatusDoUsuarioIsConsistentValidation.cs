using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class StatusDoUsuarioIsConsistentValidation : ValidatorSpecification<StatusDoUsuario>
    {
        public StatusDoUsuarioIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusDoUsuario>(Instance of is consistent specification,"message for user"));
        }

    }
}
