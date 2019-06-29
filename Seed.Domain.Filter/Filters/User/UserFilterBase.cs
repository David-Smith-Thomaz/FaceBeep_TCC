using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class UserFilterBase : FilterBase
    {

        public virtual int UserId { get; set;} 
        public virtual int StatusUserId { get; set;} 
        public virtual int TypeUserId { get; set;} 
        public virtual string Login { get; set;} 
        public virtual string Password { get; set;} 
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
