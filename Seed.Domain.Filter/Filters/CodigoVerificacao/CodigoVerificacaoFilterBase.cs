using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class CodigoVerificacaoFilterBase : FilterBase
    {

        public virtual int CodigoVerificacaoId { get; set;} 
        public virtual int ParticipanteId { get; set;} 
        public virtual Guid Codigo { get; set;} 
        public virtual DateTime DataInicioStart { get; set;} 
        public virtual DateTime DataInicioEnd { get; set;} 
        public virtual DateTime DataInicio { get; set;} 
        public virtual DateTime DataFimStart { get; set;} 
        public virtual DateTime DataFimEnd { get; set;} 
        public virtual DateTime DataFim { get; set;} 
        public virtual int statusCodigoId { get; set;} 


    }
}
