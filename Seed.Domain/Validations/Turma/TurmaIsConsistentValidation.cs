using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class TurmaIsConsistentValidation : ValidatorSpecification<Turma>
    {
        public TurmaIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Turma>(Instance of is consistent specification,"message for user"));
        }

    }
}
