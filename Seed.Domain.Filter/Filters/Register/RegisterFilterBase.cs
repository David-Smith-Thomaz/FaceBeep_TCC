using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class RegisterFilterBase : FilterBase
    {

        public virtual int RegisterId { get; set;} 
        public virtual int StatusRegisterId { get; set;} 
        public virtual int ParticipantId { get; set;} 
        public virtual string Description { get; set;} 
        public virtual DateTime EnterDateStart { get; set;} 
        public virtual DateTime EnterDateEnd { get; set;} 
        public virtual DateTime EnterDate { get; set;} 
        public virtual DateTime ExitDateStart { get; set;} 
        public virtual DateTime ExitDateEnd { get; set;} 
        public virtual DateTime ExitDate { get; set;} 


    }
}
