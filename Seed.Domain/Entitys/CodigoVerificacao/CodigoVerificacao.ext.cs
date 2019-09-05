using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class CodigoVerificacao : CodigoVerificacaoBase
    {

        public CodigoVerificacao()
        {

        }

		 public CodigoVerificacao(int codigoverificacaoid, int participanteid, Guid codigo, DateTime datainicio, DateTime datafim, int statuscodigoid) :
                          base(codigoverificacaoid, participanteid, codigo, datainicio, datafim, statuscodigoid)
                        {

                        }


		public class CodigoVerificacaoFactory : CodigoVerificacaoFactoryBase
        {
            public CodigoVerificacao GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new CodigoVerificacaoIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
