using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class FotoDoParticipanteIsConsistentValidation : ValidatorSpecification<FotoDoParticipante>
    {
        public FotoDoParticipanteIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<FotoDoParticipante>(Instance of is consistent specification,"message for user"));
        }

    }
}
