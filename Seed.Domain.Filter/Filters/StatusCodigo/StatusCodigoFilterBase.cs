using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class StatusCodigoFilterBase : FilterBase
    {

        public virtual int StatusCodigoId { get; set;} 
        public virtual string Description { get; set;} 


    }
}
