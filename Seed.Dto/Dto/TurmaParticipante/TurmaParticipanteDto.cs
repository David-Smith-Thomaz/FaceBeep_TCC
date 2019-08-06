using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class TurmaParticipanteDto  : DtoBase
	{
	
        

        public virtual int TurmaParticipanteId {get; set;}

        

        public virtual int ParticipanteId {get; set;}

        

        public virtual int TurmaId {get; set;}


		
	}
}