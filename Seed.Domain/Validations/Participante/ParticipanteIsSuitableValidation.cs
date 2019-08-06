using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class ParticipanteIsSuitableValidation : ValidatorSpecification<Participante>
    {
        public ParticipanteIsSuitableValidation(IParticipanteRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Participante>(Instance of is suitable,"message for user"));
        }

    }
}
