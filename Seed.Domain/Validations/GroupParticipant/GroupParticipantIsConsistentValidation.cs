using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class GroupParticipantIsConsistentValidation : ValidatorSpecification<GroupParticipant>
    {
        public GroupParticipantIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<GroupParticipant>(Instance of is consistent specification,"message for user"));
        }

    }
}
