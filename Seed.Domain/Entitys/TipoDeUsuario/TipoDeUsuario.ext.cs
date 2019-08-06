using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class TipoDeUsuario : TipoDeUsuarioBase
    {

        public TipoDeUsuario()
        {

        }

		 public TipoDeUsuario(int tipodeusuarioid, string descricao) :
                          base(tipodeusuarioid, descricao)
                        {

                        }


		public class TipoDeUsuarioFactory : TipoDeUsuarioFactoryBase
        {
            public TipoDeUsuario GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new TipoDeUsuarioIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
