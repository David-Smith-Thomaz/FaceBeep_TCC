using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class FotoDoParticipante : FotoDoParticipanteBase
    {

        public FotoDoParticipante()
        {

        }

        public FotoDoParticipante(int fotodoparticipateid, string descricao, string arquivo) : base(fotodoparticipateid, descricao, arquivo)
        {
        }

        public class FotoDoParticipanteFactory : FotoDoParticipanteFactoryBase
        {
            public FotoDoParticipante GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new FotoDoParticipanteIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
