using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class FotoDoParticipanteIsSuitableWarning : WarningSpecification<FotoDoParticipante>
    {
        public FotoDoParticipanteIsSuitableWarning(IFotoDoParticipanteRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<FotoDoParticipante>(Instance of suitable warning specification,"message for user"));
        }

    }
}
