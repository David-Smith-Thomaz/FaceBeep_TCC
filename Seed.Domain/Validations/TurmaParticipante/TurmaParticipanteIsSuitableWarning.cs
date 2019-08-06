using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class TurmaParticipanteIsSuitableWarning : WarningSpecification<TurmaParticipante>
    {
        public TurmaParticipanteIsSuitableWarning(ITurmaParticipanteRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TurmaParticipante>(Instance of suitable warning specification,"message for user"));
        }

    }
}
