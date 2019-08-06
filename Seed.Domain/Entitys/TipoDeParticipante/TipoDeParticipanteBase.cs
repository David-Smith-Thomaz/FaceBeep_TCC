using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class TipoDeParticipanteBase : DomainBase
    {
        public TipoDeParticipanteBase()
        {

        }

		public TipoDeParticipanteBase(int tipodeparticipanteid, string descricao) 
        {
            this.TipoDeParticipanteId = tipodeparticipanteid;
            this.Descricao = descricao;

        }


		public class TipoDeParticipanteFactoryBase
        {
            public virtual TipoDeParticipante GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new TipoDeParticipante(data.TipoDeParticipanteId,
                                        data.Descricao);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int TipoDeParticipanteId { get; protected set; }
        public virtual string Descricao { get; protected set; }



    }
}
