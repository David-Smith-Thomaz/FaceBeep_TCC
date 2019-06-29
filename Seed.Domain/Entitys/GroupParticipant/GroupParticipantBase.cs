using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class GroupParticipantBase : DomainBase
    {
        public GroupParticipantBase()
        {

        }

		public GroupParticipantBase(int groupparticipantid, string groupname, DateTime startdateperiod, DateTime enddateperiod, bool active) 
        {
            this.GroupParticipantId = groupparticipantid;
            this.GroupName = groupname;
            this.StartDatePeriod = startdateperiod;
            this.EndDatePeriod = enddateperiod;
            this.Active = active;

        }


		public class GroupParticipantFactoryBase
        {
            public virtual GroupParticipant GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new GroupParticipant(data.GroupParticipantId,
                                        data.GroupName,
                                        data.StartDatePeriod,
                                        data.EndDatePeriod,
                                        data.Active);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int GroupParticipantId { get; protected set; }
        public virtual string GroupName { get; protected set; }
        public virtual DateTime StartDatePeriod { get; protected set; }
        public virtual DateTime EndDatePeriod { get; protected set; }
        public virtual bool Active { get; protected set; }



    }
}
