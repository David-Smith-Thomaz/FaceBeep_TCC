using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class TipoDeUsuarioIsSuitableWarning : WarningSpecification<TipoDeUsuario>
    {
        public TipoDeUsuarioIsSuitableWarning(ITipoDeUsuarioRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TipoDeUsuario>(Instance of suitable warning specification,"message for user"));
        }

    }
}
