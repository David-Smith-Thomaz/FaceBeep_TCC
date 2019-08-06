using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class ParticipanteIsSuitableWarning : WarningSpecification<Participante>
    {
        public ParticipanteIsSuitableWarning(IParticipanteRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Participante>(Instance of suitable warning specification,"message for user"));
        }

    }
}
