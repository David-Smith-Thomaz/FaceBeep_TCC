using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class TipoDeUsuarioBase : DomainBase
    {
        public TipoDeUsuarioBase()
        {

        }

		public TipoDeUsuarioBase(int tipodeusuarioid, string descricao) 
        {
            this.TipoDeUsuarioId = tipodeusuarioid;
            this.Descricao = descricao;

        }


		public class TipoDeUsuarioFactoryBase
        {
            public virtual TipoDeUsuario GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new TipoDeUsuario(data.TipoDeUsuarioId,
                                        data.Descricao);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int TipoDeUsuarioId { get; protected set; }
        public virtual string Descricao { get; protected set; }



    }
}
