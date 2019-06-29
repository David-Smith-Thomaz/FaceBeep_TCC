using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class Register : RegisterBase
    {

        public Register()
        {

        }

		 public Register(int registerid, int statusregisterid, int participantid, DateTime enterdate, DateTime exitdate) :
                          base(registerid, statusregisterid, participantid, enterdate, exitdate)
                        {

                        }


		public class RegisterFactory : RegisterFactoryBase
        {
            public Register GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new RegisterIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
