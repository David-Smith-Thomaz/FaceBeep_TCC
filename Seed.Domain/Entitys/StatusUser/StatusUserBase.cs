using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class StatusUserBase : DomainBase
    {
        public StatusUserBase()
        {

        }

		public StatusUserBase(int statususerid, string description) 
        {
            this.StatusUserId = statususerid;
            this.Description = description;

        }


		public class StatusUserFactoryBase
        {
            public virtual StatusUser GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new StatusUser(data.StatusUserId,
                                        data.Description);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int StatusUserId { get; protected set; }
        public virtual string Description { get; protected set; }



    }
}
