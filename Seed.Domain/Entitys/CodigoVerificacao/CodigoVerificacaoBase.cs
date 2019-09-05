using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class CodigoVerificacaoBase : DomainBase
    {
        public CodigoVerificacaoBase()
        {

        }

		public CodigoVerificacaoBase(int codigoverificacaoid, int participanteid, Guid codigo, DateTime datainicio, DateTime datafim, int statuscodigoid) 
        {
            this.CodigoVerificacaoId = codigoverificacaoid;
            this.ParticipanteId = participanteid;
            this.Codigo = codigo;
            this.DataInicio = datainicio;
            this.DataFim = datafim;
            this.statusCodigoId = statuscodigoid;

        }


		public class CodigoVerificacaoFactoryBase
        {
            public virtual CodigoVerificacao GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new CodigoVerificacao(data.CodigoVerificacaoId,
                                        data.ParticipanteId,
                                        data.Codigo,
                                        data.DataInicio,
                                        data.DataFim,
                                        data.statusCodigoId);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int CodigoVerificacaoId { get; protected set; }
        public virtual int ParticipanteId { get; protected set; }
        public virtual Guid Codigo { get; protected set; }
        public virtual DateTime DataInicio { get; protected set; }
        public virtual DateTime DataFim { get; protected set; }
        public virtual int statusCodigoId { get; protected set; }



    }
}
