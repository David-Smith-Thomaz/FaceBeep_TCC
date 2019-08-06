using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class TurmaDto  : DtoBase
	{
	
        

        public virtual int TurmaId {get; set;}

        [Required(ErrorMessage="Turma - Campo CodigoDaTurma é Obrigatório")]
        [MaxLength(150, ErrorMessage = "Turma - Quantidade de caracteres maior que o permitido para o campo CodigoDaTurma")]
        public virtual string CodigoDaTurma {get; set;}

        [Required(ErrorMessage="Turma - Campo Nome é Obrigatório")]
        [MaxLength(150, ErrorMessage = "Turma - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}

        

        public virtual string Descricao {get; set;}

        [Required(ErrorMessage="Turma - Campo DataInicio é Obrigatório")]
        public virtual DateTime DataInicio {get; set;}

        [Required(ErrorMessage="Turma - Campo DataFim é Obrigatório")]
        public virtual DateTime DataFim {get; set;}

        

        public virtual int AdmTurmaId {get; set;}

        

        public virtual int StatusDaTurmaId {get; set;}


		
	}
}