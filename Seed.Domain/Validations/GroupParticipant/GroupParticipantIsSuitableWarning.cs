using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class GroupParticipantIsSuitableWarning : WarningSpecification<GroupParticipant>
    {
        public GroupParticipantIsSuitableWarning(IGroupParticipantRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<GroupParticipant>(Instance of suitable warning specification,"message for user"));
        }

    }
}
