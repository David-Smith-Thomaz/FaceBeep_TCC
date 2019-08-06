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
    public class TipoDeUsuarioServiceBase : ServiceBase<TipoDeUsuario>
    {
        protected readonly ITipoDeUsuarioRepository _rep;

        public TipoDeUsuarioServiceBase(ITipoDeUsuarioRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<TipoDeUsuario> GetOne(TipoDeUsuarioFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<TipoDeUsuario>> GetByFilters(TipoDeUsuarioFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<TipoDeUsuario>> GetByFiltersPaging(TipoDeUsuarioFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(TipoDeUsuario tipodeusuario)
        {
            this._rep.Remove(tipodeusuario);
        }

        public virtual Summary GetSummary(PaginateResult<TipoDeUsuario> paginateResult)
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

        public override async Task<TipoDeUsuario> Save(TipoDeUsuario tipodeusuario, bool questionToContinue = false)
        {
			var tipodeusuarioOld = await this.GetOne(new TipoDeUsuarioFilter { TipoDeUsuarioId = tipodeusuario.TipoDeUsuarioId });
			var tipodeusuarioOrchestrated = await this.DomainOrchestration(tipodeusuario, tipodeusuarioOld);

            if (questionToContinue)
            {
                if (this.Continue(tipodeusuarioOrchestrated, tipodeusuarioOld) == false)
                    return tipodeusuarioOrchestrated;
            }

            return this.SaveWithValidation(tipodeusuarioOrchestrated, tipodeusuarioOld);
        }

        public override async Task<TipoDeUsuario> SavePartial(TipoDeUsuario tipodeusuario, bool questionToContinue = false)
        {
            var tipodeusuarioOld = await this.GetOne(new TipoDeUsuarioFilter { TipoDeUsuarioId = tipodeusuario.TipoDeUsuarioId });
			var tipodeusuarioOrchestrated = await this.DomainOrchestration(tipodeusuario, tipodeusuarioOld);

            if (questionToContinue)
            {
                if (this.Continue(tipodeusuarioOrchestrated, tipodeusuarioOld) == false)
                    return tipodeusuarioOrchestrated;
            }

            return SaveWithOutValidation(tipodeusuarioOrchestrated, tipodeusuarioOld);
        }

        protected override TipoDeUsuario SaveWithOutValidation(TipoDeUsuario tipodeusuario, TipoDeUsuario tipodeusuarioOld)
        {
            tipodeusuario = this.SaveDefault(tipodeusuario, tipodeusuarioOld);
			this._cacheHelper.ClearCache();

			if (!tipodeusuario.IsValid())
			{
				this._validationResult = tipodeusuario.GetDomainValidation();
				this._validationWarning = tipodeusuario.GetDomainWarning();
				return tipodeusuario;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return tipodeusuario;
        }

		protected override TipoDeUsuario SaveWithValidation(TipoDeUsuario tipodeusuario, TipoDeUsuario tipodeusuarioOld)
        {
            if (!this.IsValid(tipodeusuario))
				return tipodeusuario;
            
            tipodeusuario = this.SaveDefault(tipodeusuario, tipodeusuarioOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return tipodeusuario;
        }
		
		protected virtual bool IsValid(TipoDeUsuario entity)
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

		protected virtual void Specifications(TipoDeUsuario tipodeusuario)
        {
            this._validationResult  = this._validationResult.Merge(new TipoDeUsuarioIsSuitableValidation(this._rep).Validate(tipodeusuario));
			this._validationWarning  = this._validationWarning.Merge(new TipoDeUsuarioIsSuitableWarning(this._rep).Validate(tipodeusuario));
        }

        protected virtual TipoDeUsuario SaveDefault(TipoDeUsuario tipodeusuario, TipoDeUsuario tipodeusuarioOld)
        {
			

            var isNew = tipodeusuarioOld.IsNull();			
            if (isNew)
                tipodeusuario = this.AddDefault(tipodeusuario);
            else
				tipodeusuario = this.UpdateDefault(tipodeusuario);

            return tipodeusuario;
        }
		
        protected virtual TipoDeUsuario AddDefault(TipoDeUsuario tipodeusuario)
        {
            tipodeusuario = this._rep.Add(tipodeusuario);
            return tipodeusuario;
        }

		protected virtual TipoDeUsuario UpdateDefault(TipoDeUsuario tipodeusuario)
        {
            tipodeusuario = this._rep.Update(tipodeusuario);
            return tipodeusuario;
        }
				
		public virtual async Task<TipoDeUsuario> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new TipoDeUsuario.TipoDeUsuarioFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<TipoDeUsuario> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new TipoDeUsuario.TipoDeUsuarioFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
