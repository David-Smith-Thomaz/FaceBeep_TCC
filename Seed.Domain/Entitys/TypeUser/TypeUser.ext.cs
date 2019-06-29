using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class TypeUser : TypeUserBase
    {

        public TypeUser()
        {

        }

		 public TypeUser(int typeuserid, string description) :
                          base(typeuserid, description)
                        {

                        }


		public class TypeUserFactory : TypeUserFactoryBase
        {
            public TypeUser GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new TypeUserIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
