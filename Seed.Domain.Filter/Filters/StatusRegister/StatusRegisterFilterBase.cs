using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class StatusRegisterFilterBase : FilterBase
    {

        public virtual int StatusRegisterId { get; set;} 
        public virtual string Description { get; set;} 


    }
}
