using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class StatusDoUsuarioDto  : DtoBase
	{
	
        

        public virtual int StatusDoUsuarioId {get; set;}

        [Required(ErrorMessage="StatusDoUsuario - Campo Descricao é Obrigatório")]
        [MaxLength(50, ErrorMessage = "StatusDoUsuario - Quantidade de caracteres maior que o permitido para o campo Descricao")]
        public virtual string Descricao {get; set;}


		
	}
}