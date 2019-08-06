using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class TurmaParticipanteIsConsistentValidation : ValidatorSpecification<TurmaParticipante>
    {
        public TurmaParticipanteIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TurmaParticipante>(Instance of is consistent specification,"message for user"));
        }

    }
}
