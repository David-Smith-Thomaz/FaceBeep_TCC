using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class TipoDeUsuarioIsConsistentValidation : ValidatorSpecification<TipoDeUsuario>
    {
        public TipoDeUsuarioIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TipoDeUsuario>(Instance of is consistent specification,"message for user"));
        }

    }
}
