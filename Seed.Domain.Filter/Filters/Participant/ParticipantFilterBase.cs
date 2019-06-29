using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class ParticipantFilterBase : FilterBase
    {

        public virtual int ParticipantId { get; set;} 
        public virtual int UserId { get; set;} 
        public virtual int? GroupParticipantId { get; set;} 
        public virtual string PhotoPerfil { get; set;} 
        public virtual string Name { get; set;} 
        public virtual string Description { get; set;} 
        public virtual int DocumentNumber { get; set;} 
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
