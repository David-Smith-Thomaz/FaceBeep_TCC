using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class GroupParticipantIsSuitableValidation : ValidatorSpecification<GroupParticipant>
    {
        public GroupParticipantIsSuitableValidation(IGroupParticipantRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<GroupParticipant>(Instance of is suitable,"message for user"));
        }

    }
}
