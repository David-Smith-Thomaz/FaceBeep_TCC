using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class Usuario : UsuarioBase
    {

        public Usuario()
        {

        }

		 public Usuario(int usuarioid, string login, string senha, string email, int statusdousuarioid, int tipodeusuarioid) :
                          base(usuarioid, login, senha, email, statusdousuarioid, tipodeusuarioid)
                        {

                        }


		public class UsuarioFactory : UsuarioFactoryBase
        {
            public Usuario GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new UsuarioIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
