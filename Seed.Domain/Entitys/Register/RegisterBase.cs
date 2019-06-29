using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class RegisterBase : DomainBase
    {
        public RegisterBase()
        {

        }

		public RegisterBase(int registerid, int statusregisterid, int participantid, DateTime enterdate, DateTime exitdate) 
        {
            this.RegisterId = registerid;
            this.StatusRegisterId = statusregisterid;
            this.ParticipantId = participantid;
            this.EnterDate = enterdate;
            this.ExitDate = exitdate;

        }


		public class RegisterFactoryBase
        {
            public virtual Register GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new Register(data.RegisterId,
                                        data.StatusRegisterId,
                                        data.ParticipantId,
                                        data.EnterDate,
                                        data.ExitDate);

                construction.SetarDescription(data.Description);


				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int RegisterId { get; protected set; }
        public virtual int StatusRegisterId { get; protected set; }
        public virtual int ParticipantId { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual DateTime EnterDate { get; protected set; }
        public virtual DateTime ExitDate { get; protected set; }

		public virtual void SetarDescription(string description)
		{
			this.Description = description;
		}


    }
}
