using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class Participant : ParticipantBase
    {

        public Participant()
        {

        }

		 public Participant(int participantid, int userid, string name, int documentnumber) :
                          base(participantid, userid, name, documentnumber)
                        {

                        }


		public class ParticipantFactory : ParticipantFactoryBase
        {
            public Participant GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new ParticipantIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
