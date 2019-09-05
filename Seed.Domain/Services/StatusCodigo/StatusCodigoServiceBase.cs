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
    public class StatusCodigoServiceBase : ServiceBase<StatusCodigo>
    {
        protected readonly IStatusCodigoRepository _rep;

        public StatusCodigoServiceBase(IStatusCodigoRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<StatusCodigo> GetOne(StatusCodigoFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<StatusCodigo>> GetByFilters(StatusCodigoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<StatusCodigo>> GetByFiltersPaging(StatusCodigoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(StatusCodigo statuscodigo)
        {
            this._rep.Remove(statuscodigo);
        }

        public virtual Summary GetSummary(PaginateResult<StatusCodigo> paginateResult)
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

        public override async Task<StatusCodigo> Save(StatusCodigo statuscodigo, bool questionToContinue = false)
        {
			var statuscodigoOld = await this.GetOne(new StatusCodigoFilter { StatusCodigoId = statuscodigo.StatusCodigoId });
			var statuscodigoOrchestrated = await this.DomainOrchestration(statuscodigo, statuscodigoOld);

            if (questionToContinue)
            {
                if (this.Continue(statuscodigoOrchestrated, statuscodigoOld) == false)
                    return statuscodigoOrchestrated;
            }

            return this.SaveWithValidation(statuscodigoOrchestrated, statuscodigoOld);
        }

        public override async Task<StatusCodigo> SavePartial(StatusCodigo statuscodigo, bool questionToContinue = false)
        {
            var statuscodigoOld = await this.GetOne(new StatusCodigoFilter { StatusCodigoId = statuscodigo.StatusCodigoId });
			var statuscodigoOrchestrated = await this.DomainOrchestration(statuscodigo, statuscodigoOld);

            if (questionToContinue)
            {
                if (this.Continue(statuscodigoOrchestrated, statuscodigoOld) == false)
                    return statuscodigoOrchestrated;
            }

            return SaveWithOutValidation(statuscodigoOrchestrated, statuscodigoOld);
        }

        protected override StatusCodigo SaveWithOutValidation(StatusCodigo statuscodigo, StatusCodigo statuscodigoOld)
        {
            statuscodigo = this.SaveDefault(statuscodigo, statuscodigoOld);
			this._cacheHelper.ClearCache();

			if (!statuscodigo.IsValid())
			{
				this._validationResult = statuscodigo.GetDomainValidation();
				this._validationWarning = statuscodigo.GetDomainWarning();
				return statuscodigo;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return statuscodigo;
        }

		protected override StatusCodigo SaveWithValidation(StatusCodigo statuscodigo, StatusCodigo statuscodigoOld)
        {
            if (!this.IsValid(statuscodigo))
				return statuscodigo;
            
            statuscodigo = this.SaveDefault(statuscodigo, statuscodigoOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return statuscodigo;
        }
		
		protected virtual bool IsValid(StatusCodigo entity)
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

		protected virtual void Specifications(StatusCodigo statuscodigo)
        {
            this._validationResult  = this._validationResult.Merge(new StatusCodigoIsSuitableValidation(this._rep).Validate(statuscodigo));
			this._validationWarning  = this._validationWarning.Merge(new StatusCodigoIsSuitableWarning(this._rep).Validate(statuscodigo));
        }

        protected virtual StatusCodigo SaveDefault(StatusCodigo statuscodigo, StatusCodigo statuscodigoOld)
        {
			

            var isNew = statuscodigoOld.IsNull();			
            if (isNew)
                statuscodigo = this.AddDefault(statuscodigo);
            else
				statuscodigo = this.UpdateDefault(statuscodigo);

            return statuscodigo;
        }
		
        protected virtual StatusCodigo AddDefault(StatusCodigo statuscodigo)
        {
            statuscodigo = this._rep.Add(statuscodigo);
            return statuscodigo;
        }

		protected virtual StatusCodigo UpdateDefault(StatusCodigo statuscodigo)
        {
            statuscodigo = this._rep.Update(statuscodigo);
            return statuscodigo;
        }
				
		public virtual async Task<StatusCodigo> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusCodigo.StatusCodigoFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<StatusCodigo> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusCodigo.StatusCodigoFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
