using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class StatusCodigoIsConsistentValidation : ValidatorSpecification<StatusCodigo>
    {
        public StatusCodigoIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusCodigo>(Instance of is consistent specification,"message for user"));
        }

    }
}
