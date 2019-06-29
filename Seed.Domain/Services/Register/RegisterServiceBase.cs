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
    public class RegisterServiceBase : ServiceBase<Register>
    {
        protected readonly IRegisterRepository _rep;

        public RegisterServiceBase(IRegisterRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<Register> GetOne(RegisterFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Register>> GetByFilters(RegisterFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Register>> GetByFiltersPaging(RegisterFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(Register register)
        {
            this._rep.Remove(register);
        }

        public virtual Summary GetSummary(PaginateResult<Register> paginateResult)
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

        public override async Task<Register> Save(Register register, bool questionToContinue = false)
        {
			var registerOld = await this.GetOne(new RegisterFilter { RegisterId = register.RegisterId });
			var registerOrchestrated = await this.DomainOrchestration(register, registerOld);

            if (questionToContinue)
            {
                if (this.Continue(registerOrchestrated, registerOld) == false)
                    return registerOrchestrated;
            }

            return this.SaveWithValidation(registerOrchestrated, registerOld);
        }

        public override async Task<Register> SavePartial(Register register, bool questionToContinue = false)
        {
            var registerOld = await this.GetOne(new RegisterFilter { RegisterId = register.RegisterId });
			var registerOrchestrated = await this.DomainOrchestration(register, registerOld);

            if (questionToContinue)
            {
                if (this.Continue(registerOrchestrated, registerOld) == false)
                    return registerOrchestrated;
            }

            return SaveWithOutValidation(registerOrchestrated, registerOld);
        }

        protected override Register SaveWithOutValidation(Register register, Register registerOld)
        {
            register = this.SaveDefault(register, registerOld);
			this._cacheHelper.ClearCache();

			if (!register.IsValid())
			{
				this._validationResult = register.GetDomainValidation();
				this._validationWarning = register.GetDomainWarning();
				return register;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return register;
        }

		protected override Register SaveWithValidation(Register register, Register registerOld)
        {
            if (!this.IsValid(register))
				return register;
            
            register = this.SaveDefault(register, registerOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return register;
        }
		
		protected virtual bool IsValid(Register entity)
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

		protected virtual void Specifications(Register register)
        {
            this._validationResult  = this._validationResult.Merge(new RegisterIsSuitableValidation(this._rep).Validate(register));
			this._validationWarning  = this._validationWarning.Merge(new RegisterIsSuitableWarning(this._rep).Validate(register));
        }

        protected virtual Register SaveDefault(Register register, Register registerOld)
        {
			

            var isNew = registerOld.IsNull();			
            if (isNew)
                register = this.AddDefault(register);
            else
				register = this.UpdateDefault(register);

            return register;
        }
		
        protected virtual Register AddDefault(Register register)
        {
            register = this._rep.Add(register);
            return register;
        }

		protected virtual Register UpdateDefault(Register register)
        {
            register = this._rep.Update(register);
            return register;
        }
				
		public virtual async Task<Register> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Register.RegisterFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<Register> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Register.RegisterFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
