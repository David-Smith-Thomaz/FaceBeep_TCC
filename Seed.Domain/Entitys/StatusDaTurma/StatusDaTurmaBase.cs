using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class StatusDaTurmaBase : DomainBase
    {
        public StatusDaTurmaBase()
        {

        }

		public StatusDaTurmaBase(int statusdaturmaid, string descricao) 
        {
            this.StatusDaTurmaId = statusdaturmaid;
            this.Descricao = descricao;

        }


		public class StatusDaTurmaFactoryBase
        {
            public virtual StatusDaTurma GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new StatusDaTurma(data.StatusDaTurmaId,
                                        data.Descricao);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int StatusDaTurmaId { get; protected set; }
        public virtual string Descricao { get; protected set; }



    }
}
