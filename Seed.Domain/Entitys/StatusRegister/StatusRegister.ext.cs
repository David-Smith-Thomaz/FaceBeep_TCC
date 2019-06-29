using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class StatusRegister : StatusRegisterBase
    {

        public StatusRegister()
        {

        }

		 public StatusRegister(int statusregisterid, string description) :
                          base(statusregisterid, description)
                        {

                        }


		public class StatusRegisterFactory : StatusRegisterFactoryBase
        {
            public StatusRegister GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new StatusRegisterIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
