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
    public class UserServiceBase : ServiceBase<User>
    {
        protected readonly IUserRepository _rep;

        public UserServiceBase(IUserRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<User> GetOne(UserFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<User>> GetByFilters(UserFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<User>> GetByFiltersPaging(UserFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(User user)
        {
            this._rep.Remove(user);
        }

        public virtual Summary GetSummary(PaginateResult<User> paginateResult)
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

        public override async Task<User> Save(User user, bool questionToContinue = false)
        {
			var userOld = await this.GetOne(new UserFilter { UserId = user.UserId });
			var userOrchestrated = await this.DomainOrchestration(user, userOld);

            if (questionToContinue)
            {
                if (this.Continue(userOrchestrated, userOld) == false)
                    return userOrchestrated;
            }

            return this.SaveWithValidation(userOrchestrated, userOld);
        }

        public override async Task<User> SavePartial(User user, bool questionToContinue = false)
        {
            var userOld = await this.GetOne(new UserFilter { UserId = user.UserId });
			var userOrchestrated = await this.DomainOrchestration(user, userOld);

            if (questionToContinue)
            {
                if (this.Continue(userOrchestrated, userOld) == false)
                    return userOrchestrated;
            }

            return SaveWithOutValidation(userOrchestrated, userOld);
        }

        protected override User SaveWithOutValidation(User user, User userOld)
        {
            user = this.SaveDefault(user, userOld);
			this._cacheHelper.ClearCache();

			if (!user.IsValid())
			{
				this._validationResult = user.GetDomainValidation();
				this._validationWarning = user.GetDomainWarning();
				return user;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return user;
        }

		protected override User SaveWithValidation(User user, User userOld)
        {
            if (!this.IsValid(user))
				return user;
            
            user = this.SaveDefault(user, userOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return user;
        }
		
		protected virtual bool IsValid(User entity)
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

		protected virtual void Specifications(User user)
        {
            this._validationResult  = this._validationResult.Merge(new UserIsSuitableValidation(this._rep).Validate(user));
			this._validationWarning  = this._validationWarning.Merge(new UserIsSuitableWarning(this._rep).Validate(user));
        }

        protected virtual User SaveDefault(User user, User userOld)
        {
			user = this.AuditDefault(user, userOld);

            var isNew = userOld.IsNull();			
            if (isNew)
                user = this.AddDefault(user);
            else
				user = this.UpdateDefault(user);

            return user;
        }
		
        protected virtual User AddDefault(User user)
        {
            user = this._rep.Add(user);
            return user;
        }

		protected virtual User UpdateDefault(User user)
        {
            user = this._rep.Update(user);
            return user;
        }
				
		public virtual async Task<User> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new User.UserFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<User> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new User.UserFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
