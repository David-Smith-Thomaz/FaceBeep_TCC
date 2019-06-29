using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class StatusRegisterBase : DomainBase
    {
        public StatusRegisterBase()
        {

        }

		public StatusRegisterBase(int statusregisterid, string description) 
        {
            this.StatusRegisterId = statusregisterid;
            this.Description = description;

        }


		public class StatusRegisterFactoryBase
        {
            public virtual StatusRegister GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new StatusRegister(data.StatusRegisterId,
                                        data.Description);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int StatusRegisterId { get; protected set; }
        public virtual string Description { get; protected set; }



    }
}
