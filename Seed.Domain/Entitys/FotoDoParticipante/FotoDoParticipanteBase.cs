using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class FotoDoParticipanteBase : DomainBaseWithUserCreate
    {
        public FotoDoParticipanteBase()
        {

        }

		public FotoDoParticipanteBase(string fotodoparticipateid) 
        {
            this.FotoDoParticipateId = fotodoparticipateid;

        }


		public class FotoDoParticipanteFactoryBase
        {
            public virtual FotoDoParticipante GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new FotoDoParticipante(data.FotoDoParticipateId);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual string FotoDoParticipateId { get; protected set; }



    }
}
