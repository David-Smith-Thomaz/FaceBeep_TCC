using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class GroupParticipantFilterBase : FilterBase
    {

        public virtual int GroupParticipantId { get; set;} 
        public virtual string GroupName { get; set;} 
        public virtual DateTime StartDatePeriodStart { get; set;} 
        public virtual DateTime StartDatePeriodEnd { get; set;} 
        public virtual DateTime StartDatePeriod { get; set;} 
        public virtual DateTime EndDatePeriodStart { get; set;} 
        public virtual DateTime EndDatePeriodEnd { get; set;} 
        public virtual DateTime EndDatePeriod { get; set;} 
        public virtual bool? Active { get; set;} 


    }
}
