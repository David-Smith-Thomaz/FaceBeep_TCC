using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class StatusCodigo : StatusCodigoBase
    {

        public StatusCodigo()
        {

        }

		 public StatusCodigo(int statuscodigoid, string description) :
                          base(statuscodigoid, description)
                        {

                        }


		public class StatusCodigoFactory : StatusCodigoFactoryBase
        {
            public StatusCodigo GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new StatusCodigoIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
