using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class TipoDeUsuarioDto  : DtoBase
	{
	
        

        public virtual int TipoDeUsuarioId {get; set;}

        [Required(ErrorMessage="TipoDeUsuario - Campo Descricao é Obrigatório")]
        [MaxLength(50, ErrorMessage = "TipoDeUsuario - Quantidade de caracteres maior que o permitido para o campo Descricao")]
        public virtual string Descricao {get; set;}


		
	}
}