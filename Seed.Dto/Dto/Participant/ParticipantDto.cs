using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class ParticipantDto  : DtoBase
	{
	
        

        public virtual int ParticipantId {get; set;}

        

        public virtual int UserId {get; set;}

        

        public virtual int? GroupParticipantId {get; set;}

        

        public virtual string PhotoPerfil {get; set;}

        [Required(ErrorMessage="Participant - Campo Name é Obrigatório")]
        [MaxLength(50, ErrorMessage = "Participant - Quantidade de caracteres maior que o permitido para o campo Name")]
        public virtual string Name {get; set;}

        

        public virtual string Description {get; set;}

        [Required(ErrorMessage="Participant - Campo DocumentNumber é Obrigatório")]
        public virtual int DocumentNumber {get; set;}


		
	}
}