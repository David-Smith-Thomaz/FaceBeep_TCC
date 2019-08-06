using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class TipoDeParticipanteDto  : DtoBase
	{
	
        

        public virtual int TipoDeParticipanteId {get; set;}

        [Required(ErrorMessage="TipoDeParticipante - Campo Descricao é Obrigatório")]
        [MaxLength(50, ErrorMessage = "TipoDeParticipante - Quantidade de caracteres maior que o permitido para o campo Descricao")]
        public virtual string Descricao {get; set;}


		
	}
}