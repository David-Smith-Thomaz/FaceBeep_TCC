using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class TurmaFilterBase : FilterBase
    {

        public virtual int TurmaId { get; set;} 
        public virtual string CodigoDaTurma { get; set;} 
        public virtual string Nome { get; set;} 
        public virtual string Descricao { get; set;} 
        public virtual DateTime DataInicioStart { get; set;} 
        public virtual DateTime DataInicioEnd { get; set;} 
        public virtual DateTime DataInicio { get; set;} 
        public virtual DateTime DataFimStart { get; set;} 
        public virtual DateTime DataFimEnd { get; set;} 
        public virtual DateTime DataFim { get; set;} 
        public virtual int AdmTurmaId { get; set;} 
        public virtual int StatusDaTurmaId { get; set;} 
        public virtual int? UserAlterId { get; set;} 
        public virtual DateTime? UserAlterDateStart { get; set;} 
        public virtual DateTime? UserAlterDateEnd { get; set;} 
        public virtual DateTime? UserAlterDate { get; set;} 
        public virtual int UserCreateId { get; set;} 
        public virtual DateTime UserCreateDateStart { get; set;} 
        public virtual DateTime UserCreateDateEnd { get; set;} 
        public virtual DateTime UserCreateDate { get; set;} 


    }
}
