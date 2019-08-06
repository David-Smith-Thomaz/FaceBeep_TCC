using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class TurmaParticipanteIsSuitableValidation : ValidatorSpecification<TurmaParticipante>
    {
        public TurmaParticipanteIsSuitableValidation(ITurmaParticipanteRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TurmaParticipante>(Instance of is suitable,"message for user"));
        }

    }
}
