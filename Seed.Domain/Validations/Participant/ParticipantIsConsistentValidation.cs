using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class ParticipantIsConsistentValidation : ValidatorSpecification<Participant>
    {
        public ParticipantIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Participant>(Instance of is consistent specification,"message for user"));
        }

    }
}
