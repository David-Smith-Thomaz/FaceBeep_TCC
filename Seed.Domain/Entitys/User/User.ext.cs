using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class User : UserBase
    {

        public User()
        {

        }

		 public User(int userid, int statususerid, int typeuserid, string login, string password) :
                          base(userid, statususerid, typeuserid, login, password)
                        {

                        }


		public class UserFactory : UserFactoryBase
        {
            public User GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new UserIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
