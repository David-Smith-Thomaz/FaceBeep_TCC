using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class FotoDoParticipanteDto  : DtoBase
	{
	
        

        public virtual int FotoDoParticipateId {get; set;}

        [Required(ErrorMessage="FotoDoParticipante - Campo Descricao é Obrigatório")]
        [MaxLength(150, ErrorMessage = "FotoDoParticipante - Quantidade de caracteres maior que o permitido para o campo Descricao")]
        public virtual string Descricao {get; set;}

        [Required(ErrorMessage="FotoDoParticipante - Campo Arquivo é Obrigatório")]
        public virtual string Arquivo {get; set;}


		
	}
}