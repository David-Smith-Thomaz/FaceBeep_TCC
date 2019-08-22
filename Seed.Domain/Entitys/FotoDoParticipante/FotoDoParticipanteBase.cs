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

		public FotoDoParticipanteBase(int fotodoparticipateid, string descricao) 
        {
            this.FotoDoParticipateId = fotodoparticipateid;
            this.Descricao = descricao;

        }


		public class FotoDoParticipanteFactoryBase
        {
            public virtual FotoDoParticipante GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new FotoDoParticipante(data.FotoDoParticipateId,
                                        data.Descricao);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int FotoDoParticipateId { get; protected set; }
        public virtual string Descricao { get; protected set; }



    }
}
