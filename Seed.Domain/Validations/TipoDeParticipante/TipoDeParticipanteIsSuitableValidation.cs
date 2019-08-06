using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class TipoDeParticipanteIsSuitableValidation : ValidatorSpecification<TipoDeParticipante>
    {
        public TipoDeParticipanteIsSuitableValidation(ITipoDeParticipanteRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TipoDeParticipante>(Instance of is suitable,"message for user"));
        }

    }
}
