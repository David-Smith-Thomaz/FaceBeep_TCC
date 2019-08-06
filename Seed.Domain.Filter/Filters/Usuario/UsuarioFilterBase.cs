using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class UsuarioFilterBase : FilterBase
    {

        public virtual int UsuarioId { get; set;} 
        public virtual string Login { get; set;} 
        public virtual string Senha { get; set;} 
        public virtual string Email { get; set;} 
        public virtual int StatusDoUsuarioId { get; set;} 
        public virtual int TipoDeUsuarioId { get; set;} 
        public virtual int? ParticipanteId { get; set;} 
        public virtual int UserCreateId { get; set;} 
        public virtual DateTime UserCreateDateStart { get; set;} 
        public virtual DateTime UserCreateDateEnd { get; set;} 
        public virtual DateTime UserCreateDate { get; set;} 
        public virtual int? UserAlterId { get; set;} 
        public virtual DateTime? UserAlterDateStart { get; set;} 
        public virtual DateTime? UserAlterDateEnd { get; set;} 
        public virtual DateTime? UserAlterDate { get; set;} 


    }
}
