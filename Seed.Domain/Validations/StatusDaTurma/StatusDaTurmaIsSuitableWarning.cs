using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class StatusDaTurmaIsSuitableWarning : WarningSpecification<StatusDaTurma>
    {
        public StatusDaTurmaIsSuitableWarning(IStatusDaTurmaRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusDaTurma>(Instance of suitable warning specification,"message for user"));
        }

    }
}
