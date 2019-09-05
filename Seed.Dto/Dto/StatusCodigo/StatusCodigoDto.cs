using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class StatusCodigoDto  : DtoBase
	{
	
        

        public virtual int StatusCodigoId {get; set;}

        [Required(ErrorMessage="StatusCodigo - Campo Description é Obrigatório")]
        [MaxLength(50, ErrorMessage = "StatusCodigo - Quantidade de caracteres maior que o permitido para o campo Description")]
        public virtual string Description {get; set;}


		
	}
}