using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class ParticipanteBase : DomainBaseWithUserCreate
    {
        public ParticipanteBase()
        {

        }

		public ParticipanteBase(int participanteid, int usuarioid, int tipodeparticipanteid, string nomecompleto, DateTime datadenascimento, string endereco, string bairro, int numerocasa, string cep) 
        {
            this.ParticipanteId = participanteid;
            this.UsuarioId = usuarioid;
            this.TipoDeParticipanteId = tipodeparticipanteid;
            this.NomeCompleto = nomecompleto;
            this.DataDenascimento = datadenascimento;
            this.Endereco = endereco;
            this.Bairro = bairro;
            this.NumeroCasa = numerocasa;
            this.Cep = cep;

        }


		public class ParticipanteFactoryBase
        {
            public virtual Participante GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new Participante(data.ParticipanteId,
                                        data.UsuarioId,
                                        data.TipoDeParticipanteId,
                                        data.NomeCompleto,
                                        data.DataDenascimento,
                                        data.Endereco,
                                        data.Bairro,
                                        data.NumeroCasa,
                                        data.Cep);

                construction.SetarApelido(data.Apelido);


				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int ParticipanteId { get; protected set; }
        public virtual int UsuarioId { get; protected set; }
        public virtual string Apelido { get; protected set; }
        public virtual int TipoDeParticipanteId { get; protected set; }
        public virtual string NomeCompleto { get; protected set; }
        public virtual DateTime DataDenascimento { get; protected set; }
        public virtual string Endereco { get; protected set; }
        public virtual string Bairro { get; protected set; }
        public virtual int NumeroCasa { get; protected set; }
        public virtual string Cep { get; protected set; }

		public virtual void SetarApelido(string apelido)
		{
			this.Apelido = apelido;
		}


    }
}
