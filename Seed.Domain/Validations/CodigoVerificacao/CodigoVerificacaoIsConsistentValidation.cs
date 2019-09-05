using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class CodigoVerificacaoIsConsistentValidation : ValidatorSpecification<CodigoVerificacao>
    {
        public CodigoVerificacaoIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<CodigoVerificacao>(Instance of is consistent specification,"message for user"));
        }

    }
}
