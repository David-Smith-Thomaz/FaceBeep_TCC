using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class StatusDaTurma : StatusDaTurmaBase
    {

        public StatusDaTurma()
        {

        }

		 public StatusDaTurma(int statusdaturmaid, string descricao) :
                          base(statusdaturmaid, descricao)
                        {

                        }


		public class StatusDaTurmaFactory : StatusDaTurmaFactoryBase
        {
            public StatusDaTurma GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new StatusDaTurmaIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
