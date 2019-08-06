using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class TipoDeParticipanteFilterBase : FilterBase
    {

        public virtual int TipoDeParticipanteId { get; set;} 
        public virtual string Descricao { get; set;} 


    }
}
