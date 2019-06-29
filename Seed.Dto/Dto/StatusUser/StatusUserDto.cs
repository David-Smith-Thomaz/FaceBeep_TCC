using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class StatusUserDto  : DtoBase
	{
	
        

        public virtual int StatusUserId {get; set;}

        [Required(ErrorMessage="StatusUser - Campo Description é Obrigatório")]
        [MaxLength(50, ErrorMessage = "StatusUser - Quantidade de caracteres maior que o permitido para o campo Description")]
        public virtual string Description {get; set;}


		
	}
}