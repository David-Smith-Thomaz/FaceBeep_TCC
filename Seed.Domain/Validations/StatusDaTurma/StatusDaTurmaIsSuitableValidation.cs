using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class StatusDaTurmaIsSuitableValidation : ValidatorSpecification<StatusDaTurma>
    {
        public StatusDaTurmaIsSuitableValidation(IStatusDaTurmaRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusDaTurma>(Instance of is suitable,"message for user"));
        }

    }
}
