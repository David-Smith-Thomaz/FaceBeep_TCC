using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class TipoDeUsuarioIsSuitableValidation : ValidatorSpecification<TipoDeUsuario>
    {
        public TipoDeUsuarioIsSuitableValidation(ITipoDeUsuarioRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TipoDeUsuario>(Instance of is suitable,"message for user"));
        }

    }
}
