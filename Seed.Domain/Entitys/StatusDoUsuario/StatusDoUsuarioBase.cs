using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class StatusDoUsuarioBase : DomainBase
    {
        public StatusDoUsuarioBase()
        {

        }

		public StatusDoUsuarioBase(int statusdousuarioid, string descricao) 
        {
            this.StatusDoUsuarioId = statusdousuarioid;
            this.Descricao = descricao;

        }


		public class StatusDoUsuarioFactoryBase
        {
            public virtual StatusDoUsuario GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new StatusDoUsuario(data.StatusDoUsuarioId,
                                        data.Descricao);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int StatusDoUsuarioId { get; protected set; }
        public virtual string Descricao { get; protected set; }



    }
}
