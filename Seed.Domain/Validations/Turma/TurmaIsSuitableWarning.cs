using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class TurmaIsSuitableWarning : WarningSpecification<Turma>
    {
        public TurmaIsSuitableWarning(ITurmaRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Turma>(Instance of suitable warning specification,"message for user"));
        }

    }
}
