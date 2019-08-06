using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class UsuarioIsSuitableValidation : ValidatorSpecification<Usuario>
    {
        public UsuarioIsSuitableValidation(IUsuarioRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Usuario>(Instance of is suitable,"message for user"));
        }

    }
}
