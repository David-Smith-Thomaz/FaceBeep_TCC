using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class TipoDeParticipanteIsSuitableWarning : WarningSpecification<TipoDeParticipante>
    {
        public TipoDeParticipanteIsSuitableWarning(ITipoDeParticipanteRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TipoDeParticipante>(Instance of suitable warning specification,"message for user"));
        }

    }
}
