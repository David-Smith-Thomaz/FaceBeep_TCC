using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class TipoDeParticipanteIsConsistentValidation : ValidatorSpecification<TipoDeParticipante>
    {
        public TipoDeParticipanteIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TipoDeParticipante>(Instance of is consistent specification,"message for user"));
        }

    }
}
