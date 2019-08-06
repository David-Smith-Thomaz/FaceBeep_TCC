using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class StatusDoUsuarioIsSuitableWarning : WarningSpecification<StatusDoUsuario>
    {
        public StatusDoUsuarioIsSuitableWarning(IStatusDoUsuarioRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusDoUsuario>(Instance of suitable warning specification,"message for user"));
        }

    }
}
