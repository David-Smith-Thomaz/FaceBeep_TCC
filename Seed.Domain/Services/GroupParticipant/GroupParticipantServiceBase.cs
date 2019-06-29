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
    public class GroupParticipantServiceBase : ServiceBase<GroupParticipant>
    {
        protected readonly IGroupParticipantRepository _rep;

        public GroupParticipantServiceBase(IGroupParticipantRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<GroupParticipant> GetOne(GroupParticipantFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<GroupParticipant>> GetByFilters(GroupParticipantFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<GroupParticipant>> GetByFiltersPaging(GroupParticipantFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(GroupParticipant groupparticipant)
        {
            this._rep.Remove(groupparticipant);
        }

        public virtual Summary GetSummary(PaginateResult<GroupParticipant> paginateResult)
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

        public override async Task<GroupParticipant> Save(GroupParticipant groupparticipant, bool questionToContinue = false)
        {
			var groupparticipantOld = await this.GetOne(new GroupParticipantFilter { GroupParticipantId = groupparticipant.GroupParticipantId });
			var groupparticipantOrchestrated = await this.DomainOrchestration(groupparticipant, groupparticipantOld);

            if (questionToContinue)
            {
                if (this.Continue(groupparticipantOrchestrated, groupparticipantOld) == false)
                    return groupparticipantOrchestrated;
            }

            return this.SaveWithValidation(groupparticipantOrchestrated, groupparticipantOld);
        }

        public override async Task<GroupParticipant> SavePartial(GroupParticipant groupparticipant, bool questionToContinue = false)
        {
            var groupparticipantOld = await this.GetOne(new GroupParticipantFilter { GroupParticipantId = groupparticipant.GroupParticipantId });
			var groupparticipantOrchestrated = await this.DomainOrchestration(groupparticipant, groupparticipantOld);

            if (questionToContinue)
            {
                if (this.Continue(groupparticipantOrchestrated, groupparticipantOld) == false)
                    return groupparticipantOrchestrated;
            }

            return SaveWithOutValidation(groupparticipantOrchestrated, groupparticipantOld);
        }

        protected override GroupParticipant SaveWithOutValidation(GroupParticipant groupparticipant, GroupParticipant groupparticipantOld)
        {
            groupparticipant = this.SaveDefault(groupparticipant, groupparticipantOld);
			this._cacheHelper.ClearCache();

			if (!groupparticipant.IsValid())
			{
				this._validationResult = groupparticipant.GetDomainValidation();
				this._validationWarning = groupparticipant.GetDomainWarning();
				return groupparticipant;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return groupparticipant;
        }

		protected override GroupParticipant SaveWithValidation(GroupParticipant groupparticipant, GroupParticipant groupparticipantOld)
        {
            if (!this.IsValid(groupparticipant))
				return groupparticipant;
            
            groupparticipant = this.SaveDefault(groupparticipant, groupparticipantOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return groupparticipant;
        }
		
		protected virtual bool IsValid(GroupParticipant entity)
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

		protected virtual void Specifications(GroupParticipant groupparticipant)
        {
            this._validationResult  = this._validationResult.Merge(new GroupParticipantIsSuitableValidation(this._rep).Validate(groupparticipant));
			this._validationWarning  = this._validationWarning.Merge(new GroupParticipantIsSuitableWarning(this._rep).Validate(groupparticipant));
        }

        protected virtual GroupParticipant SaveDefault(GroupParticipant groupparticipant, GroupParticipant groupparticipantOld)
        {
			

            var isNew = groupparticipantOld.IsNull();			
            if (isNew)
                groupparticipant = this.AddDefault(groupparticipant);
            else
				groupparticipant = this.UpdateDefault(groupparticipant);

            return groupparticipant;
        }
		
        protected virtual GroupParticipant AddDefault(GroupParticipant groupparticipant)
        {
            groupparticipant = this._rep.Add(groupparticipant);
            return groupparticipant;
        }

		protected virtual GroupParticipant UpdateDefault(GroupParticipant groupparticipant)
        {
            groupparticipant = this._rep.Update(groupparticipant);
            return groupparticipant;
        }
				
		public virtual async Task<GroupParticipant> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new GroupParticipant.GroupParticipantFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<GroupParticipant> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new GroupParticipant.GroupParticipantFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
