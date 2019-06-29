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
    public class StatusRegisterServiceBase : ServiceBase<StatusRegister>
    {
        protected readonly IStatusRegisterRepository _rep;

        public StatusRegisterServiceBase(IStatusRegisterRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<StatusRegister> GetOne(StatusRegisterFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<StatusRegister>> GetByFilters(StatusRegisterFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<StatusRegister>> GetByFiltersPaging(StatusRegisterFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(StatusRegister statusregister)
        {
            this._rep.Remove(statusregister);
        }

        public virtual Summary GetSummary(PaginateResult<StatusRegister> paginateResult)
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

        public override async Task<StatusRegister> Save(StatusRegister statusregister, bool questionToContinue = false)
        {
			var statusregisterOld = await this.GetOne(new StatusRegisterFilter { StatusRegisterId = statusregister.StatusRegisterId });
			var statusregisterOrchestrated = await this.DomainOrchestration(statusregister, statusregisterOld);

            if (questionToContinue)
            {
                if (this.Continue(statusregisterOrchestrated, statusregisterOld) == false)
                    return statusregisterOrchestrated;
            }

            return this.SaveWithValidation(statusregisterOrchestrated, statusregisterOld);
        }

        public override async Task<StatusRegister> SavePartial(StatusRegister statusregister, bool questionToContinue = false)
        {
            var statusregisterOld = await this.GetOne(new StatusRegisterFilter { StatusRegisterId = statusregister.StatusRegisterId });
			var statusregisterOrchestrated = await this.DomainOrchestration(statusregister, statusregisterOld);

            if (questionToContinue)
            {
                if (this.Continue(statusregisterOrchestrated, statusregisterOld) == false)
                    return statusregisterOrchestrated;
            }

            return SaveWithOutValidation(statusregisterOrchestrated, statusregisterOld);
        }

        protected override StatusRegister SaveWithOutValidation(StatusRegister statusregister, StatusRegister statusregisterOld)
        {
            statusregister = this.SaveDefault(statusregister, statusregisterOld);
			this._cacheHelper.ClearCache();

			if (!statusregister.IsValid())
			{
				this._validationResult = statusregister.GetDomainValidation();
				this._validationWarning = statusregister.GetDomainWarning();
				return statusregister;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return statusregister;
        }

		protected override StatusRegister SaveWithValidation(StatusRegister statusregister, StatusRegister statusregisterOld)
        {
            if (!this.IsValid(statusregister))
				return statusregister;
            
            statusregister = this.SaveDefault(statusregister, statusregisterOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return statusregister;
        }
		
		protected virtual bool IsValid(StatusRegister entity)
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

		protected virtual void Specifications(StatusRegister statusregister)
        {
            this._validationResult  = this._validationResult.Merge(new StatusRegisterIsSuitableValidation(this._rep).Validate(statusregister));
			this._validationWarning  = this._validationWarning.Merge(new StatusRegisterIsSuitableWarning(this._rep).Validate(statusregister));
        }

        protected virtual StatusRegister SaveDefault(StatusRegister statusregister, StatusRegister statusregisterOld)
        {
			

            var isNew = statusregisterOld.IsNull();			
            if (isNew)
                statusregister = this.AddDefault(statusregister);
            else
				statusregister = this.UpdateDefault(statusregister);

            return statusregister;
        }
		
        protected virtual StatusRegister AddDefault(StatusRegister statusregister)
        {
            statusregister = this._rep.Add(statusregister);
            return statusregister;
        }

		protected virtual StatusRegister UpdateDefault(StatusRegister statusregister)
        {
            statusregister = this._rep.Update(statusregister);
            return statusregister;
        }
				
		public virtual async Task<StatusRegister> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusRegister.StatusRegisterFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<StatusRegister> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusRegister.StatusRegisterFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
