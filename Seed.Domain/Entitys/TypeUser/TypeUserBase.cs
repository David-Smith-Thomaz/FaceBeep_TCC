using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class TypeUserBase : DomainBase
    {
        public TypeUserBase()
        {

        }

		public TypeUserBase(int typeuserid, string description) 
        {
            this.TypeUserId = typeuserid;
            this.Description = description;

        }


		public class TypeUserFactoryBase
        {
            public virtual TypeUser GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new TypeUser(data.TypeUserId,
                                        data.Description);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int TypeUserId { get; protected set; }
        public virtual string Description { get; protected set; }



    }
}
