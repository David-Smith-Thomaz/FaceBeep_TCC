using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Repository;
using Seed.Domain.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seed.Domain.Services
{
    public class TurmaServiceBase : ServiceBase<Turma>
    {
        protected readonly ITurmaRepository _rep;

        public TurmaServiceBase(ITurmaRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<Turma> GetOne(TurmaFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Turma>> GetByFilters(TurmaFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Turma>> GetByFiltersPaging(TurmaFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(Turma turma)
        {
            this._rep.Remove(turma);
        }

        public virtual Summary GetSummary(PaginateResult<Turma> paginateResult)
        {
            return new Summary
            {
                Total = paginateResult.TotalCount,
				PageSize = paginateResult.PageSize,
            };
        }

        public virtual ValidationSpecificationResult GetDomainValidation(FilterBase filters = null)
        {
            return this._validationResult;
        }

        public virtual ConfirmEspecificationResult GetDomainConfirm(FilterBase filters = null)
        {
            return this._validationConfirm;
        }

        public virtual WarningSpecificationResult GetDomainWarning(FilterBase filters = null)
        {
            return this._validationWarning;
        }

        public override async Task<Turma> Save(Turma turma, bool questionToContinue = false)
        {
			var turmaOld = await this.GetOne(new TurmaFilter { TurmaId = turma.TurmaId });
			var turmaOrchestrated = await this.DomainOrchestration(turma, turmaOld);

            if (questionToContinue)
            {
                if (this.Continue(turmaOrchestrated, turmaOld) == false)
                    return turmaOrchestrated;
            }

            return this.SaveWithValidation(turmaOrchestrated, turmaOld);
        }

        public override async Task<Turma> SavePartial(Turma turma, bool questionToContinue = false)
        {
            var turmaOld = await this.GetOne(new TurmaFilter { TurmaId = turma.TurmaId });
			var turmaOrchestrated = await this.DomainOrchestration(turma, turmaOld);

            if (questionToContinue)
            {
                if (this.Continue(turmaOrchestrated, turmaOld) == false)
                    return turmaOrchestrated;
            }

            return SaveWithOutValidation(turmaOrchestrated, turmaOld);
        }

        protected override Turma SaveWithOutValidation(Turma turma, Turma turmaOld)
        {
            turma = this.SaveDefault(turma, turmaOld);
			this._cacheHelper.ClearCache();

			if (!turma.IsValid())
			{
				this._validationResult = turma.GetDomainValidation();
				this._validationWarning = turma.GetDomainWarning();
				return turma;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return turma;
        }

		protected override Turma SaveWithValidation(Turma turma, Turma turmaOld)
        {
            if (!this.IsValid(turma))
				return turma;
            
            turma = this.SaveDefault(turma, turmaOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return turma;
        }
		
		protected virtual bool IsValid(Turma entity)
        {
            var isValid = true;
            if (!this.DataAnnotationIsValid() || !entity.IsValid())
            {
                if (this._validationResult.IsNull())
                    this._validationResult = entity.GetDomainValidation();
                else
                    this._validationResult.Merge(entity.GetDomainValidation());

                if (this._validationWarning.IsNull())
                    this._validationWarning = entity.GetDomainWarning();
                else
                    this._validationWarning.Merge(entity.GetDomainWarning());

                isValid = false;
            }

            this.Specifications(entity);
            if (!this._validationResult.IsValid)
                isValid = false;

            return isValid;
        }

		protected virtual void Specifications(Turma turma)
        {
            this._validationResult  = this._validationResult.Merge(new TurmaIsSuitableValidation(this._rep).Validate(turma));
			this._validationWarning  = this._validationWarning.Merge(new TurmaIsSuitableWarning(this._rep).Validate(turma));
        }

        protected virtual Turma SaveDefault(Turma turma, Turma turmaOld)
        {
			turma = this.AuditDefault(turma, turmaOld);

            var isNew = turmaOld.IsNull();			
            if (isNew)
                turma = this.AddDefault(turma);
            else
				turma = this.UpdateDefault(turma);

            return turma;
        }
		
        protected virtual Turma AddDefault(Turma turma)
        {
            turma = this._rep.Add(turma);
            return turma;
        }

		protected virtual Turma UpdateDefault(Turma turma)
        {
            turma = this._rep.Update(turma);
            return turma;
        }
				
		public virtual async Task<Turma> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Turma.TurmaFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<Turma> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Turma.TurmaFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
