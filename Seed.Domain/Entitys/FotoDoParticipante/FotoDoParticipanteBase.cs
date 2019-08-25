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

		public FotoDoParticipanteBase(int fotodoparticipateid, string descricao, string arquivo) 
        {
            this.FotoDoParticipateId = fotodoparticipateid;
            this.Descricao = descricao;
            this.Arquivo = arquivo;

        }


		public class FotoDoParticipanteFactoryBase
        {
            public virtual FotoDoParticipante GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new FotoDoParticipante(data.FotoDoParticipateId,
                                        data.Descricao,
                                        data.Arquivo);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int FotoDoParticipateId { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual string Arquivo { get; protected set; }



    }
}
