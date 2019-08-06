using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class TipoDeParticipante : TipoDeParticipanteBase
    {

        public TipoDeParticipante()
        {

        }

		 public TipoDeParticipante(int tipodeparticipanteid, string descricao) :
                          base(tipodeparticipanteid, descricao)
                        {

                        }


		public class TipoDeParticipanteFactory : TipoDeParticipanteFactoryBase
        {
            public TipoDeParticipante GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new TipoDeParticipanteIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
