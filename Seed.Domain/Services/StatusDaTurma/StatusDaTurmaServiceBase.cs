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
    public class StatusDaTurmaServiceBase : ServiceBase<StatusDaTurma>
    {
        protected readonly IStatusDaTurmaRepository _rep;

        public StatusDaTurmaServiceBase(IStatusDaTurmaRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<StatusDaTurma> GetOne(StatusDaTurmaFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<StatusDaTurma>> GetByFilters(StatusDaTurmaFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<StatusDaTurma>> GetByFiltersPaging(StatusDaTurmaFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(StatusDaTurma statusdaturma)
        {
            this._rep.Remove(statusdaturma);
        }

        public virtual Summary GetSummary(PaginateResult<StatusDaTurma> paginateResult)
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

        public override async Task<StatusDaTurma> Save(StatusDaTurma statusdaturma, bool questionToContinue = false)
        {
			var statusdaturmaOld = await this.GetOne(new StatusDaTurmaFilter { StatusDaTurmaId = statusdaturma.StatusDaTurmaId });
			var statusdaturmaOrchestrated = await this.DomainOrchestration(statusdaturma, statusdaturmaOld);

            if (questionToContinue)
            {
                if (this.Continue(statusdaturmaOrchestrated, statusdaturmaOld) == false)
                    return statusdaturmaOrchestrated;
            }

            return this.SaveWithValidation(statusdaturmaOrchestrated, statusdaturmaOld);
        }

        public override async Task<StatusDaTurma> SavePartial(StatusDaTurma statusdaturma, bool questionToContinue = false)
        {
            var statusdaturmaOld = await this.GetOne(new StatusDaTurmaFilter { StatusDaTurmaId = statusdaturma.StatusDaTurmaId });
			var statusdaturmaOrchestrated = await this.DomainOrchestration(statusdaturma, statusdaturmaOld);

            if (questionToContinue)
            {
                if (this.Continue(statusdaturmaOrchestrated, statusdaturmaOld) == false)
                    return statusdaturmaOrchestrated;
            }

            return SaveWithOutValidation(statusdaturmaOrchestrated, statusdaturmaOld);
        }

        protected override StatusDaTurma SaveWithOutValidation(StatusDaTurma statusdaturma, StatusDaTurma statusdaturmaOld)
        {
            statusdaturma = this.SaveDefault(statusdaturma, statusdaturmaOld);
			this._cacheHelper.ClearCache();

			if (!statusdaturma.IsValid())
			{
				this._validationResult = statusdaturma.GetDomainValidation();
				this._validationWarning = statusdaturma.GetDomainWarning();
				return statusdaturma;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return statusdaturma;
        }

		protected override StatusDaTurma SaveWithValidation(StatusDaTurma statusdaturma, StatusDaTurma statusdaturmaOld)
        {
            if (!this.IsValid(statusdaturma))
				return statusdaturma;
            
            statusdaturma = this.SaveDefault(statusdaturma, statusdaturmaOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return statusdaturma;
        }
		
		protected virtual bool IsValid(StatusDaTurma entity)
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

		protected virtual void Specifications(StatusDaTurma statusdaturma)
        {
            this._validationResult  = this._validationResult.Merge(new StatusDaTurmaIsSuitableValidation(this._rep).Validate(statusdaturma));
			this._validationWarning  = this._validationWarning.Merge(new StatusDaTurmaIsSuitableWarning(this._rep).Validate(statusdaturma));
        }

        protected virtual StatusDaTurma SaveDefault(StatusDaTurma statusdaturma, StatusDaTurma statusdaturmaOld)
        {
			

            var isNew = statusdaturmaOld.IsNull();			
            if (isNew)
                statusdaturma = this.AddDefault(statusdaturma);
            else
				statusdaturma = this.UpdateDefault(statusdaturma);

            return statusdaturma;
        }
		
        protected virtual StatusDaTurma AddDefault(StatusDaTurma statusdaturma)
        {
            statusdaturma = this._rep.Add(statusdaturma);
            return statusdaturma;
        }

		protected virtual StatusDaTurma UpdateDefault(StatusDaTurma statusdaturma)
        {
            statusdaturma = this._rep.Update(statusdaturma);
            return statusdaturma;
        }
				
		public virtual async Task<StatusDaTurma> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusDaTurma.StatusDaTurmaFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<StatusDaTurma> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusDaTurma.StatusDaTurmaFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
