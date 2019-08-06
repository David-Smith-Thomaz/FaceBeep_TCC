using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class Turma : TurmaBase
    {

        public Turma()
        {

        }

		 public Turma(int turmaid, string codigodaturma, string nome, DateTime datainicio, DateTime datafim, int admturmaid, int statusdaturmaid) :
                          base(turmaid, codigodaturma, nome, datainicio, datafim, admturmaid, statusdaturmaid)
                        {

                        }


		public class TurmaFactory : TurmaFactoryBase
        {
            public Turma GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new TurmaIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
