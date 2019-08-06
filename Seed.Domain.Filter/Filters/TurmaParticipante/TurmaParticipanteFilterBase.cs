using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class TurmaParticipanteFilterBase : FilterBase
    {

        public virtual int TurmaParticipanteId { get; set;} 
        public virtual int ParticipanteId { get; set;} 
        public virtual int TurmaId { get; set;} 


    }
}
