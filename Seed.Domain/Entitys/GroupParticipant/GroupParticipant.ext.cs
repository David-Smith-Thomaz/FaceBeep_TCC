using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class GroupParticipant : GroupParticipantBase
    {

        public GroupParticipant()
        {

        }

		 public GroupParticipant(int groupparticipantid, string groupname, DateTime startdateperiod, DateTime enddateperiod, bool active) :
                          base(groupparticipantid, groupname, startdateperiod, enddateperiod, active)
                        {

                        }


		public class GroupParticipantFactory : GroupParticipantFactoryBase
        {
            public GroupParticipant GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new GroupParticipantIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
