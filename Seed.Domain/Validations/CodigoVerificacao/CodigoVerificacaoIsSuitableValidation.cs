﻿using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class CodigoVerificacaoIsSuitableValidation : ValidatorSpecification<CodigoVerificacao>
    {
        public CodigoVerificacaoIsSuitableValidation(ICodigoVerificacaoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<CodigoVerificacao>(Instance of is suitable,"message for user"));
        }

    }
}
