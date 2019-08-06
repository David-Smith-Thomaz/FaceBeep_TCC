using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class StatusDoUsuarioIsSuitableValidation : ValidatorSpecification<StatusDoUsuario>
    {
        public StatusDoUsuarioIsSuitableValidation(IStatusDoUsuarioRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusDoUsuario>(Instance of is suitable,"message for user"));
        }

    }
}
