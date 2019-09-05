using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class StatusCodigoIsSuitableValidation : ValidatorSpecification<StatusCodigo>
    {
        public StatusCodigoIsSuitableValidation(IStatusCodigoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusCodigo>(Instance of is suitable,"message for user"));
        }

    }
}
