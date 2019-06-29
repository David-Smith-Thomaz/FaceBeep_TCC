using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class TypeUserDto  : DtoBase
	{
	
        

        public virtual int TypeUserId {get; set;}

        [Required(ErrorMessage="TypeUser - Campo Description é Obrigatório")]
        [MaxLength(300, ErrorMessage = "TypeUser - Quantidade de caracteres maior que o permitido para o campo Description")]
        public virtual string Description {get; set;}


		
	}
}