using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class ParticipanteIsConsistentValidation : ValidatorSpecification<Participante>
    {
        public ParticipanteIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Participante>(Instance of is consistent specification,"message for user"));
        }

    }
}
