using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class StatusUserFilterBase : FilterBase
    {

        public virtual int StatusUserId { get; set;} 
        public virtual string Description { get; set;} 


    }
}
