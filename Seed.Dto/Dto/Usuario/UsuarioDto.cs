using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class UsuarioDto  : DtoBase
	{
	
        

        public virtual int UsuarioId {get; set;}

        [Required(ErrorMessage="Usuario - Campo Login é Obrigatório")]
        [MaxLength(50, ErrorMessage = "Usuario - Quantidade de caracteres maior que o permitido para o campo Login")]
        public virtual string Login {get; set;}

        [Required(ErrorMessage="Usuario - Campo Senha é Obrigatório")]
        [MaxLength(50, ErrorMessage = "Usuario - Quantidade de caracteres maior que o permitido para o campo Senha")]
        public virtual string Senha {get; set;}

        [Required(ErrorMessage="Usuario - Campo Email é Obrigatório")]
        [MaxLength(50, ErrorMessage = "Usuario - Quantidade de caracteres maior que o permitido para o campo Email")]
        public virtual string Email {get; set;}

        

        public virtual int StatusDoUsuarioId {get; set;}

        

        public virtual int TipoDeUsuarioId {get; set;}

        

        public virtual int? ParticipanteId {get; set;}


		
	}
}