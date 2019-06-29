using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class ParticipantIsSuitableValidation : ValidatorSpecification<Participant>
    {
        public ParticipantIsSuitableValidation(IParticipantRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Participant>(Instance of is suitable,"message for user"));
        }

    }
}
