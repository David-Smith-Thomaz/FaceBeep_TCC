using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class StatusDaTurmaIsConsistentValidation : ValidatorSpecification<StatusDaTurma>
    {
        public StatusDaTurmaIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusDaTurma>(Instance of is consistent specification,"message for user"));
        }

    }
}
