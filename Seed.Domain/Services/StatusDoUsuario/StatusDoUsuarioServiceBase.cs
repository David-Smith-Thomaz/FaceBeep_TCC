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
    public class StatusDoUsuarioServiceBase : ServiceBase<StatusDoUsuario>
    {
        protected readonly IStatusDoUsuarioRepository _rep;

        public StatusDoUsuarioServiceBase(IStatusDoUsuarioRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<StatusDoUsuario> GetOne(StatusDoUsuarioFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<StatusDoUsuario>> GetByFilters(StatusDoUsuarioFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<StatusDoUsuario>> GetByFiltersPaging(StatusDoUsuarioFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(StatusDoUsuario statusdousuario)
        {
            this._rep.Remove(statusdousuario);
        }

        public virtual Summary GetSummary(PaginateResult<StatusDoUsuario> paginateResult)
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

        public override async Task<StatusDoUsuario> Save(StatusDoUsuario statusdousuario, bool questionToContinue = false)
        {
			var statusdousuarioOld = await this.GetOne(new StatusDoUsuarioFilter { StatusDoUsuarioId = statusdousuario.StatusDoUsuarioId });
			var statusdousuarioOrchestrated = await this.DomainOrchestration(statusdousuario, statusdousuarioOld);

            if (questionToContinue)
            {
                if (this.Continue(statusdousuarioOrchestrated, statusdousuarioOld) == false)
                    return statusdousuarioOrchestrated;
            }

            return this.SaveWithValidation(statusdousuarioOrchestrated, statusdousuarioOld);
        }

        public override async Task<StatusDoUsuario> SavePartial(StatusDoUsuario statusdousuario, bool questionToContinue = false)
        {
            var statusdousuarioOld = await this.GetOne(new StatusDoUsuarioFilter { StatusDoUsuarioId = statusdousuario.StatusDoUsuarioId });
			var statusdousuarioOrchestrated = await this.DomainOrchestration(statusdousuario, statusdousuarioOld);

            if (questionToContinue)
            {
                if (this.Continue(statusdousuarioOrchestrated, statusdousuarioOld) == false)
                    return statusdousuarioOrchestrated;
            }

            return SaveWithOutValidation(statusdousuarioOrchestrated, statusdousuarioOld);
        }

        protected override StatusDoUsuario SaveWithOutValidation(StatusDoUsuario statusdousuario, StatusDoUsuario statusdousuarioOld)
        {
            statusdousuario = this.SaveDefault(statusdousuario, statusdousuarioOld);
			this._cacheHelper.ClearCache();

			if (!statusdousuario.IsValid())
			{
				this._validationResult = statusdousuario.GetDomainValidation();
				this._validationWarning = statusdousuario.GetDomainWarning();
				return statusdousuario;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return statusdousuario;
        }

		protected override StatusDoUsuario SaveWithValidation(StatusDoUsuario statusdousuario, StatusDoUsuario statusdousuarioOld)
        {
            if (!this.IsValid(statusdousuario))
				return statusdousuario;
            
            statusdousuario = this.SaveDefault(statusdousuario, statusdousuarioOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return statusdousuario;
        }
		
		protected virtual bool IsValid(StatusDoUsuario entity)
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

		protected virtual void Specifications(StatusDoUsuario statusdousuario)
        {
            this._validationResult  = this._validationResult.Merge(new StatusDoUsuarioIsSuitableValidation(this._rep).Validate(statusdousuario));
			this._validationWarning  = this._validationWarning.Merge(new StatusDoUsuarioIsSuitableWarning(this._rep).Validate(statusdousuario));
        }

        protected virtual StatusDoUsuario SaveDefault(StatusDoUsuario statusdousuario, StatusDoUsuario statusdousuarioOld)
        {
			

            var isNew = statusdousuarioOld.IsNull();			
            if (isNew)
                statusdousuario = this.AddDefault(statusdousuario);
            else
				statusdousuario = this.UpdateDefault(statusdousuario);

            return statusdousuario;
        }
		
        protected virtual StatusDoUsuario AddDefault(StatusDoUsuario statusdousuario)
        {
            statusdousuario = this._rep.Add(statusdousuario);
            return statusdousuario;
        }

		protected virtual StatusDoUsuario UpdateDefault(StatusDoUsuario statusdousuario)
        {
            statusdousuario = this._rep.Update(statusdousuario);
            return statusdousuario;
        }
				
		public virtual async Task<StatusDoUsuario> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusDoUsuario.StatusDoUsuarioFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<StatusDoUsuario> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusDoUsuario.StatusDoUsuarioFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
