using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class TypeUserFilterBase : FilterBase
    {

        public virtual int TypeUserId { get; set;} 
        public virtual string Description { get; set;} 


    }
}
