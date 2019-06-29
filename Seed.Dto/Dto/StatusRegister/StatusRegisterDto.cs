using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class StatusRegisterDto  : DtoBase
	{
	
        

        public virtual int StatusRegisterId {get; set;}

        [Required(ErrorMessage="StatusRegister - Campo Description é Obrigatório")]
        [MaxLength(50, ErrorMessage = "StatusRegister - Quantidade de caracteres maior que o permitido para o campo Description")]
        public virtual string Description {get; set;}


		
	}
}