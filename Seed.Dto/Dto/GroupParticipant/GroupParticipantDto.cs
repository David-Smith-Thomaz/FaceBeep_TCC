using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class GroupParticipantDto  : DtoBase
	{
	
        

        public virtual int GroupParticipantId {get; set;}

        [Required(ErrorMessage="GroupParticipant - Campo GroupName é Obrigatório")]
        [MaxLength(100, ErrorMessage = "GroupParticipant - Quantidade de caracteres maior que o permitido para o campo GroupName")]
        public virtual string GroupName {get; set;}

        [Required(ErrorMessage="GroupParticipant - Campo StartDatePeriod é Obrigatório")]
        public virtual DateTime StartDatePeriod {get; set;}

        [Required(ErrorMessage="GroupParticipant - Campo EndDatePeriod é Obrigatório")]
        public virtual DateTime EndDatePeriod {get; set;}

        [Required(ErrorMessage="GroupParticipant - Campo Active é Obrigatório")]
        public virtual bool Active {get; set;}


		
	}
}