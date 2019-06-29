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
    public class TypeUserServiceBase : ServiceBase<TypeUser>
    {
        protected readonly ITypeUserRepository _rep;

        public TypeUserServiceBase(ITypeUserRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<TypeUser> GetOne(TypeUserFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<TypeUser>> GetByFilters(TypeUserFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<TypeUser>> GetByFiltersPaging(TypeUserFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(TypeUser typeuser)
        {
            this._rep.Remove(typeuser);
        }

        public virtual Summary GetSummary(PaginateResult<TypeUser> paginateResult)
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

        public override async Task<TypeUser> Save(TypeUser typeuser, bool questionToContinue = false)
        {
			var typeuserOld = await this.GetOne(new TypeUserFilter { TypeUserId = typeuser.TypeUserId });
			var typeuserOrchestrated = await this.DomainOrchestration(typeuser, typeuserOld);

            if (questionToContinue)
            {
                if (this.Continue(typeuserOrchestrated, typeuserOld) == false)
                    return typeuserOrchestrated;
            }

            return this.SaveWithValidation(typeuserOrchestrated, typeuserOld);
        }

        public override async Task<TypeUser> SavePartial(TypeUser typeuser, bool questionToContinue = false)
        {
            var typeuserOld = await this.GetOne(new TypeUserFilter { TypeUserId = typeuser.TypeUserId });
			var typeuserOrchestrated = await this.DomainOrchestration(typeuser, typeuserOld);

            if (questionToContinue)
            {
                if (this.Continue(typeuserOrchestrated, typeuserOld) == false)
                    return typeuserOrchestrated;
            }

            return SaveWithOutValidation(typeuserOrchestrated, typeuserOld);
        }

        protected override TypeUser SaveWithOutValidation(TypeUser typeuser, TypeUser typeuserOld)
        {
            typeuser = this.SaveDefault(typeuser, typeuserOld);
			this._cacheHelper.ClearCache();

			if (!typeuser.IsValid())
			{
				this._validationResult = typeuser.GetDomainValidation();
				this._validationWarning = typeuser.GetDomainWarning();
				return typeuser;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return typeuser;
        }

		protected override TypeUser SaveWithValidation(TypeUser typeuser, TypeUser typeuserOld)
        {
            if (!this.IsValid(typeuser))
				return typeuser;
            
            typeuser = this.SaveDefault(typeuser, typeuserOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return typeuser;
        }
		
		protected virtual bool IsValid(TypeUser entity)
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

		protected virtual void Specifications(TypeUser typeuser)
        {
            this._validationResult  = this._validationResult.Merge(new TypeUserIsSuitableValidation(this._rep).Validate(typeuser));
			this._validationWarning  = this._validationWarning.Merge(new TypeUserIsSuitableWarning(this._rep).Validate(typeuser));
        }

        protected virtual TypeUser SaveDefault(TypeUser typeuser, TypeUser typeuserOld)
        {
			

            var isNew = typeuserOld.IsNull();			
            if (isNew)
                typeuser = this.AddDefault(typeuser);
            else
				typeuser = this.UpdateDefault(typeuser);

            return typeuser;
        }
		
        protected virtual TypeUser AddDefault(TypeUser typeuser)
        {
            typeuser = this._rep.Add(typeuser);
            return typeuser;
        }

		protected virtual TypeUser UpdateDefault(TypeUser typeuser)
        {
            typeuser = this._rep.Update(typeuser);
            return typeuser;
        }
				
		public virtual async Task<TypeUser> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new TypeUser.TypeUserFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<TypeUser> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new TypeUser.TypeUserFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
