using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class StatusDoUsuario : StatusDoUsuarioBase
    {

        public StatusDoUsuario()
        {

        }

		 public StatusDoUsuario(int statusdousuarioid, string descricao) :
                          base(statusdousuarioid, descricao)
                        {

                        }


		public class StatusDoUsuarioFactory : StatusDoUsuarioFactoryBase
        {
            public StatusDoUsuario GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new StatusDoUsuarioIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
