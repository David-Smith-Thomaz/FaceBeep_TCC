using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class CodigoVerificacaoDto  : DtoBase
	{
	
        

        public virtual int CodigoVerificacaoId {get; set;}

        

        public virtual int ParticipanteId {get; set;}

        [Required(ErrorMessage="CodigoVerificacao - Campo Codigo é Obrigatório")]
        public virtual Guid Codigo {get; set;}

        [Required(ErrorMessage="CodigoVerificacao - Campo DataInicio é Obrigatório")]
        public virtual DateTime DataInicio {get; set;}

        [Required(ErrorMessage="CodigoVerificacao - Campo DataFim é Obrigatório")]
        public virtual DateTime DataFim {get; set;}

        

        public virtual int statusCodigoId {get; set;}


		
	}
}