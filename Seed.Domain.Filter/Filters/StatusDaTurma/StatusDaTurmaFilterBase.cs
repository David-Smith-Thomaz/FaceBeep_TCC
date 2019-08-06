using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class StatusDaTurmaFilterBase : FilterBase
    {

        public virtual int StatusDaTurmaId { get; set;} 
        public virtual string Descricao { get; set;} 


    }
}
