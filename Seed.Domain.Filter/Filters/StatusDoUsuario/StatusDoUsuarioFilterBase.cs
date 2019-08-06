using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class StatusDoUsuarioFilterBase : FilterBase
    {

        public virtual int StatusDoUsuarioId { get; set;} 
        public virtual string Descricao { get; set;} 


    }
}
