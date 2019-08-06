using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class TurmaIsSuitableValidation : ValidatorSpecification<Turma>
    {
        public TurmaIsSuitableValidation(ITurmaRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Turma>(Instance of is suitable,"message for user"));
        }

    }
}
