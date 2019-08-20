using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class FotoDoParticipanteIsSuitableValidation : ValidatorSpecification<FotoDoParticipante>
    {
        public FotoDoParticipanteIsSuitableValidation(IFotoDoParticipanteRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<FotoDoParticipante>(Instance of is suitable,"message for user"));
        }

    }
}
