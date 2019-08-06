using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class TipoDeUsuarioFilterBase : FilterBase
    {

        public virtual int TipoDeUsuarioId { get; set;} 
        public virtual string Descricao { get; set;} 


    }
}
