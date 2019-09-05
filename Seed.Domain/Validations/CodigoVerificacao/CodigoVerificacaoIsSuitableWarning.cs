using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class CodigoVerificacaoIsSuitableWarning : WarningSpecification<CodigoVerificacao>
    {
        public CodigoVerificacaoIsSuitableWarning(ICodigoVerificacaoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<CodigoVerificacao>(Instance of suitable warning specification,"message for user"));
        }

    }
}
