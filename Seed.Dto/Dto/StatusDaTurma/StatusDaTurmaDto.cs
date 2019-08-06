using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class StatusDaTurmaDto  : DtoBase
	{
	
        

        public virtual int StatusDaTurmaId {get; set;}

        [Required(ErrorMessage="StatusDaTurma - Campo Descricao é Obrigatório")]
        [MaxLength(50, ErrorMessage = "StatusDaTurma - Quantidade de caracteres maior que o permitido para o campo Descricao")]
        public virtual string Descricao {get; set;}


		
	}
}