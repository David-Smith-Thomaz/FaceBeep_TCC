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
    public class TipoDeParticipanteServiceBase : ServiceBase<TipoDeParticipante>
    {
        protected readonly ITipoDeParticipanteRepository _rep;

        public TipoDeParticipanteServiceBase(ITipoDeParticipanteRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<TipoDeParticipante> GetOne(TipoDeParticipanteFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<TipoDeParticipante>> GetByFilters(TipoDeParticipanteFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<TipoDeParticipante>> GetByFiltersPaging(TipoDeParticipanteFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(TipoDeParticipante tipodeparticipante)
        {
            this._rep.Remove(tipodeparticipante);
        }

        public virtual Summary GetSummary(PaginateResult<TipoDeParticipante> paginateResult)
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

        public override async Task<TipoDeParticipante> Save(TipoDeParticipante tipodeparticipante, bool questionToContinue = false)
        {
			var tipodeparticipanteOld = await this.GetOne(new TipoDeParticipanteFilter { TipoDeParticipanteId = tipodeparticipante.TipoDeParticipanteId });
			var tipodeparticipanteOrchestrated = await this.DomainOrchestration(tipodeparticipante, tipodeparticipanteOld);

            if (questionToContinue)
            {
                if (this.Continue(tipodeparticipanteOrchestrated, tipodeparticipanteOld) == false)
                    return tipodeparticipanteOrchestrated;
            }

            return this.SaveWithValidation(tipodeparticipanteOrchestrated, tipodeparticipanteOld);
        }

        public override async Task<TipoDeParticipante> SavePartial(TipoDeParticipante tipodeparticipante, bool questionToContinue = false)
        {
            var tipodeparticipanteOld = await this.GetOne(new TipoDeParticipanteFilter { TipoDeParticipanteId = tipodeparticipante.TipoDeParticipanteId });
			var tipodeparticipanteOrchestrated = await this.DomainOrchestration(tipodeparticipante, tipodeparticipanteOld);

            if (questionToContinue)
            {
                if (this.Continue(tipodeparticipanteOrchestrated, tipodeparticipanteOld) == false)
                    return tipodeparticipanteOrchestrated;
            }

            return SaveWithOutValidation(tipodeparticipanteOrchestrated, tipodeparticipanteOld);
        }

        protected override TipoDeParticipante SaveWithOutValidation(TipoDeParticipante tipodeparticipante, TipoDeParticipante tipodeparticipanteOld)
        {
            tipodeparticipante = this.SaveDefault(tipodeparticipante, tipodeparticipanteOld);
			this._cacheHelper.ClearCache();

			if (!tipodeparticipante.IsValid())
			{
				this._validationResult = tipodeparticipante.GetDomainValidation();
				this._validationWarning = tipodeparticipante.GetDomainWarning();
				return tipodeparticipante;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return tipodeparticipante;
        }

		protected override TipoDeParticipante SaveWithValidation(TipoDeParticipante tipodeparticipante, TipoDeParticipante tipodeparticipanteOld)
        {
            if (!this.IsValid(tipodeparticipante))
				return tipodeparticipante;
            
            tipodeparticipante = this.SaveDefault(tipodeparticipante, tipodeparticipanteOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return tipodeparticipante;
        }
		
		protected virtual bool IsValid(TipoDeParticipante entity)
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

		protected virtual void Specifications(TipoDeParticipante tipodeparticipante)
        {
            this._validationResult  = this._validationResult.Merge(new TipoDeParticipanteIsSuitableValidation(this._rep).Validate(tipodeparticipante));
			this._validationWarning  = this._validationWarning.Merge(new TipoDeParticipanteIsSuitableWarning(this._rep).Validate(tipodeparticipante));
        }

        protected virtual TipoDeParticipante SaveDefault(TipoDeParticipante tipodeparticipante, TipoDeParticipante tipodeparticipanteOld)
        {
			

            var isNew = tipodeparticipanteOld.IsNull();			
            if (isNew)
                tipodeparticipante = this.AddDefault(tipodeparticipante);
            else
				tipodeparticipante = this.UpdateDefault(tipodeparticipante);

            return tipodeparticipante;
        }
		
        protected virtual TipoDeParticipante AddDefault(TipoDeParticipante tipodeparticipante)
        {
            tipodeparticipante = this._rep.Add(tipodeparticipante);
            return tipodeparticipante;
        }

		protected virtual TipoDeParticipante UpdateDefault(TipoDeParticipante tipodeparticipante)
        {
            tipodeparticipante = this._rep.Update(tipodeparticipante);
            return tipodeparticipante;
        }
				
		public virtual async Task<TipoDeParticipante> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new TipoDeParticipante.TipoDeParticipanteFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<TipoDeParticipante> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new TipoDeParticipante.TipoDeParticipanteFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
