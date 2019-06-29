using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class ParticipantIsSuitableWarning : WarningSpecification<Participant>
    {
        public ParticipantIsSuitableWarning(IParticipantRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Participant>(Instance of suitable warning specification,"message for user"));
        }

    }
}
