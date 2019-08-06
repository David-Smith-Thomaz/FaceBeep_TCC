using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class TurmaParticipanteBase : DomainBase
    {
        public TurmaParticipanteBase()
        {

        }

		public TurmaParticipanteBase(int turmaparticipanteid, int participanteid, int turmaid) 
        {
            this.TurmaParticipanteId = turmaparticipanteid;
            this.ParticipanteId = participanteid;
            this.TurmaId = turmaid;

        }


		public class TurmaParticipanteFactoryBase
        {
            public virtual TurmaParticipante GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new TurmaParticipante(data.TurmaParticipanteId,
                                        data.ParticipanteId,
                                        data.TurmaId);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int TurmaParticipanteId { get; protected set; }
        public virtual int ParticipanteId { get; protected set; }
        public virtual int TurmaId { get; protected set; }



    }
}
