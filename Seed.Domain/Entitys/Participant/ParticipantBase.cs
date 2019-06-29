using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class ParticipantBase : DomainBaseWithUserCreate
    {
        public ParticipantBase()
        {

        }

		public ParticipantBase(int participantid, int userid, string name, int documentnumber) 
        {
            this.ParticipantId = participantid;
            this.UserId = userid;
            this.Name = name;
            this.DocumentNumber = documentnumber;

        }


		public class ParticipantFactoryBase
        {
            public virtual Participant GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new Participant(data.ParticipantId,
                                        data.UserId,
                                        data.Name,
                                        data.DocumentNumber);

                construction.SetarGroupParticipantId(data.GroupParticipantId);
                construction.SetarPhotoPerfil(data.PhotoPerfil);
                construction.SetarDescription(data.Description);


				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int ParticipantId { get; protected set; }
        public virtual int UserId { get; protected set; }
        public virtual int? GroupParticipantId { get; protected set; }
        public virtual string PhotoPerfil { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual int DocumentNumber { get; protected set; }

		public virtual void SetarGroupParticipantId(int? groupparticipantid)
		{
			this.GroupParticipantId = groupparticipantid;
		}
		public virtual void SetarPhotoPerfil(string photoperfil)
		{
			this.PhotoPerfil = photoperfil;
		}
		public virtual void SetarDescription(string description)
		{
			this.Description = description;
		}


    }
}
