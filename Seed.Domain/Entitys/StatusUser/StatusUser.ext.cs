using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class StatusUser : StatusUserBase
    {

        public StatusUser()
        {

        }

		 public StatusUser(int statususerid, string description) :
                          base(statususerid, description)
                        {

                        }


		public class StatusUserFactory : StatusUserFactoryBase
        {
            public StatusUser GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new StatusUserIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
