using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class UserDto  : DtoBase
	{
	
        

        public virtual int UserId {get; set;}

        

        public virtual int StatusUserId {get; set;}

        

        public virtual int TypeUserId {get; set;}

        [Required(ErrorMessage="User - Campo Login é Obrigatório")]
        [MaxLength(50, ErrorMessage = "User - Quantidade de caracteres maior que o permitido para o campo Login")]
        public virtual string Login {get; set;}

        [Required(ErrorMessage="User - Campo Password é Obrigatório")]
        [MaxLength(150, ErrorMessage = "User - Quantidade de caracteres maior que o permitido para o campo Password")]
        public virtual string Password {get; set;}


		
	}
}