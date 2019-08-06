using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class TurmaBase : DomainBaseWithUserCreate
    {
        public TurmaBase()
        {

        }

		public TurmaBase(int turmaid, string codigodaturma, string nome, DateTime datainicio, DateTime datafim, int admturmaid, int statusdaturmaid) 
        {
            this.TurmaId = turmaid;
            this.CodigoDaTurma = codigodaturma;
            this.Nome = nome;
            this.DataInicio = datainicio;
            this.DataFim = datafim;
            this.AdmTurmaId = admturmaid;
            this.StatusDaTurmaId = statusdaturmaid;

        }


		public class TurmaFactoryBase
        {
            public virtual Turma GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new Turma(data.TurmaId,
                                        data.CodigoDaTurma,
                                        data.Nome,
                                        data.DataInicio,
                                        data.DataFim,
                                        data.AdmTurmaId,
                                        data.StatusDaTurmaId);

                construction.SetarDescricao(data.Descricao);


				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int TurmaId { get; protected set; }
        public virtual string CodigoDaTurma { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual DateTime DataInicio { get; protected set; }
        public virtual DateTime DataFim { get; protected set; }
        public virtual int AdmTurmaId { get; protected set; }
        public virtual int StatusDaTurmaId { get; protected set; }

		public virtual void SetarDescricao(string descricao)
		{
			this.Descricao = descricao;
		}


    }
}
