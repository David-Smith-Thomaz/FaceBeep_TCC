using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class UsuarioBase : DomainBaseWithUserCreate
    {
        public UsuarioBase()
        {

        }

		public UsuarioBase(int usuarioid, string login, string senha, string email, int statusdousuarioid, int tipodeusuarioid) 
        {
            this.UsuarioId = usuarioid;
            this.Login = login;
            this.Senha = senha;
            this.Email = email;
            this.StatusDoUsuarioId = statusdousuarioid;
            this.TipoDeUsuarioId = tipodeusuarioid;

        }


		public class UsuarioFactoryBase
        {
            public virtual Usuario GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new Usuario(data.UsuarioId,
                                        data.Login,
                                        data.Senha,
                                        data.Email,
                                        data.StatusDoUsuarioId,
                                        data.TipoDeUsuarioId);

                construction.SetarParticipanteId(data.ParticipanteId);


				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int UsuarioId { get; protected set; }
        public virtual string Login { get; protected set; }
        public virtual string Senha { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual int StatusDoUsuarioId { get; protected set; }
        public virtual int TipoDeUsuarioId { get; protected set; }
        public virtual int? ParticipanteId { get; protected set; }

		public virtual void SetarParticipanteId(int? participanteid)
		{
			this.ParticipanteId = participanteid;
		}


    }
}
