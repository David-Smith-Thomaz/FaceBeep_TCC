using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class RegisterDto  : DtoBase
	{
	
        

        public virtual int RegisterId {get; set;}

        

        public virtual int StatusRegisterId {get; set;}

        

        public virtual int ParticipantId {get; set;}

        

        public virtual string Description {get; set;}

        [Required(ErrorMessage="Register - Campo EnterDate é Obrigatório")]
        public virtual DateTime EnterDate {get; set;}

        [Required(ErrorMessage="Register - Campo ExitDate é Obrigatório")]
        public virtual DateTime ExitDate {get; set;}


		
	}
}