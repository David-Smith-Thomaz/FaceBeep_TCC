using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class UsuarioIsSuitableWarning : WarningSpecification<Usuario>
    {
        public UsuarioIsSuitableWarning(IUsuarioRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Usuario>(Instance of suitable warning specification,"message for user"));
        }

    }
}
