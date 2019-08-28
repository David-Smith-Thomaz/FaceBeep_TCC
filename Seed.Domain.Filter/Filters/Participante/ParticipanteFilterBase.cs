using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class ParticipanteFilterBase : FilterBase
    {

        public virtual int ParticipanteId { get; set;} 
        public virtual int UsuarioId { get; set;} 
        public virtual Guid? CodigoADM { get; set;} 
        public virtual string Apelido { get; set;} 
        public virtual int TipoDeParticipanteId { get; set;} 
        public virtual string NomeCompleto { get; set;} 
        public virtual DateTime DataDenascimentoStart { get; set;} 
        public virtual DateTime DataDenascimentoEnd { get; set;} 
        public virtual DateTime DataDenascimento { get; set;} 
        public virtual string Endereco { get; set;} 
        public virtual string Bairro { get; set;} 
        public virtual int NumeroCasa { get; set;} 
        public virtual string Cep { get; set;} 
        public virtual int FotoDoParticipanteId { get; set;} 
        public virtual DateTime? UserAlterDateStart { get; set;} 
        public virtual DateTime? UserAlterDateEnd { get; set;} 
        public virtual DateTime? UserAlterDate { get; set;} 
        public virtual int UserCreateId { get; set;} 
        public virtual DateTime UserCreateDateStart { get; set;} 
        public virtual DateTime UserCreateDateEnd { get; set;} 
        public virtual DateTime UserCreateDate { get; set;} 
        public virtual int? UserAlterId { get; set;} 


    }
}
