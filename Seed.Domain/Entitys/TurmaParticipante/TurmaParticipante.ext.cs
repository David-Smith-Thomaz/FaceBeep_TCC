using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class TurmaParticipante : TurmaParticipanteBase
    {

        public TurmaParticipante()
        {

        }

		 public TurmaParticipante(int turmaparticipanteid, int participanteid, int turmaid) :
                          base(turmaparticipanteid, participanteid, turmaid)
                        {

                        }


		public class TurmaParticipanteFactory : TurmaParticipanteFactoryBase
        {
            public TurmaParticipante GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new TurmaParticipanteIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
