using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class StatusCodigoIsSuitableWarning : WarningSpecification<StatusCodigo>
    {
        public StatusCodigoIsSuitableWarning(IStatusCodigoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusCodigo>(Instance of suitable warning specification,"message for user"));
        }

    }
}
