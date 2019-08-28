using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class ParticipanteDto  : DtoBase
	{
	
        

        public virtual int ParticipanteId {get; set;}

        

        public virtual int UsuarioId {get; set;}

        

        public virtual Guid? CodigoADM {get; set;}

        

        public virtual string Apelido {get; set;}

        

        public virtual int TipoDeParticipanteId {get; set;}

        [Required(ErrorMessage="Participante - Campo NomeCompleto é Obrigatório")]
        [MaxLength(150, ErrorMessage = "Participante - Quantidade de caracteres maior que o permitido para o campo NomeCompleto")]
        public virtual string NomeCompleto {get; set;}

        [Required(ErrorMessage="Participante - Campo DataDenascimento é Obrigatório")]
        public virtual DateTime DataDenascimento {get; set;}

        [Required(ErrorMessage="Participante - Campo Endereco é Obrigatório")]
        [MaxLength(150, ErrorMessage = "Participante - Quantidade de caracteres maior que o permitido para o campo Endereco")]
        public virtual string Endereco {get; set;}

        [Required(ErrorMessage="Participante - Campo Bairro é Obrigatório")]
        [MaxLength(150, ErrorMessage = "Participante - Quantidade de caracteres maior que o permitido para o campo Bairro")]
        public virtual string Bairro {get; set;}

        [Required(ErrorMessage="Participante - Campo NumeroCasa é Obrigatório")]
        public virtual int NumeroCasa {get; set;}

        [Required(ErrorMessage="Participante - Campo Cep é Obrigatório")]
        [MaxLength(50, ErrorMessage = "Participante - Quantidade de caracteres maior que o permitido para o campo Cep")]
        public virtual string Cep {get; set;}

        

        public virtual int FotoDoParticipanteId {get; set;}


		
	}
}