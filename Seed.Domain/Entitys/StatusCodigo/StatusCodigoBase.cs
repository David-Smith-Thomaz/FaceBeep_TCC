using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class StatusCodigoBase : DomainBase
    {
        public StatusCodigoBase()
        {

        }

		public StatusCodigoBase(int statuscodigoid, string description) 
        {
            this.StatusCodigoId = statuscodigoid;
            this.Description = description;

        }


		public class StatusCodigoFactoryBase
        {
            public virtual StatusCodigo GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new StatusCodigo(data.StatusCodigoId,
                                        data.Description);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int StatusCodigoId { get; protected set; }
        public virtual string Description { get; protected set; }



    }
}
