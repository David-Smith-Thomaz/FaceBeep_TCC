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
    public class StatusUserServiceBase : ServiceBase<StatusUser>
    {
        protected readonly IStatusUserRepository _rep;

        public StatusUserServiceBase(IStatusUserRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<StatusUser> GetOne(StatusUserFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<StatusUser>> GetByFilters(StatusUserFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<StatusUser>> GetByFiltersPaging(StatusUserFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(StatusUser statususer)
        {
            this._rep.Remove(statususer);
        }

        public virtual Summary GetSummary(PaginateResult<StatusUser> paginateResult)
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

        public override async Task<StatusUser> Save(StatusUser statususer, bool questionToContinue = false)
        {
			var statususerOld = await this.GetOne(new StatusUserFilter { StatusUserId = statususer.StatusUserId });
			var statususerOrchestrated = await this.DomainOrchestration(statususer, statususerOld);

            if (questionToContinue)
            {
                if (this.Continue(statususerOrchestrated, statususerOld) == false)
                    return statususerOrchestrated;
            }

            return this.SaveWithValidation(statususerOrchestrated, statususerOld);
        }

        public override async Task<StatusUser> SavePartial(StatusUser statususer, bool questionToContinue = false)
        {
            var statususerOld = await this.GetOne(new StatusUserFilter { StatusUserId = statususer.StatusUserId });
			var statususerOrchestrated = await this.DomainOrchestration(statususer, statususerOld);

            if (questionToContinue)
            {
                if (this.Continue(statususerOrchestrated, statususerOld) == false)
                    return statususerOrchestrated;
            }

            return SaveWithOutValidation(statususerOrchestrated, statususerOld);
        }

        protected override StatusUser SaveWithOutValidation(StatusUser statususer, StatusUser statususerOld)
        {
            statususer = this.SaveDefault(statususer, statususerOld);
			this._cacheHelper.ClearCache();

			if (!statususer.IsValid())
			{
				this._validationResult = statususer.GetDomainValidation();
				this._validationWarning = statususer.GetDomainWarning();
				return statususer;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return statususer;
        }

		protected override StatusUser SaveWithValidation(StatusUser statususer, StatusUser statususerOld)
        {
            if (!this.IsValid(statususer))
				return statususer;
            
            statususer = this.SaveDefault(statususer, statususerOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return statususer;
        }
		
		protected virtual bool IsValid(StatusUser entity)
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

		protected virtual void Specifications(StatusUser statususer)
        {
            this._validationResult  = this._validationResult.Merge(new StatusUserIsSuitableValidation(this._rep).Validate(statususer));
			this._validationWarning  = this._validationWarning.Merge(new StatusUserIsSuitableWarning(this._rep).Validate(statususer));
        }

        protected virtual StatusUser SaveDefault(StatusUser statususer, StatusUser statususerOld)
        {
			

            var isNew = statususerOld.IsNull();			
            if (isNew)
                statususer = this.AddDefault(statususer);
            else
				statususer = this.UpdateDefault(statususer);

            return statususer;
        }
		
        protected virtual StatusUser AddDefault(StatusUser statususer)
        {
            statususer = this._rep.Add(statususer);
            return statususer;
        }

		protected virtual StatusUser UpdateDefault(StatusUser statususer)
        {
            statususer = this._rep.Update(statususer);
            return statususer;
        }
				
		public virtual async Task<StatusUser> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusUser.StatusUserFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<StatusUser> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusUser.StatusUserFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
