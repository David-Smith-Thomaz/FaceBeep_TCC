using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class Participante : ParticipanteBase
    {

        public Participante()
        {

        }

        public Participante(int participanteid, int usuarioid, int tipodeparticipanteid, string nomecompleto, DateTime datadenascimento, string endereco, string bairro, int numerocasa, string cep, int fotodoparticipanteid) : base(participanteid, usuarioid, tipodeparticipanteid, nomecompleto, datadenascimento, endereco, bairro, numerocasa, cep, fotodoparticipanteid)
        {
        }

        public class ParticipanteFactory : ParticipanteFactoryBase
        {
            public Participante GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new ParticipanteIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
