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
    public class FotoDoParticipanteServiceBase : ServiceBase<FotoDoParticipante>
    {
        protected readonly IFotoDoParticipanteRepository _rep;

        public FotoDoParticipanteServiceBase(IFotoDoParticipanteRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<FotoDoParticipante> GetOne(FotoDoParticipanteFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<FotoDoParticipante>> GetByFilters(FotoDoParticipanteFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<FotoDoParticipante>> GetByFiltersPaging(FotoDoParticipanteFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(FotoDoParticipante fotodoparticipante)
        {
            this._rep.Remove(fotodoparticipante);
        }

        public virtual Summary GetSummary(PaginateResult<FotoDoParticipante> paginateResult)
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

        public override async Task<FotoDoParticipante> Save(FotoDoParticipante fotodoparticipante, bool questionToContinue = false)
        {
			var fotodoparticipanteOld = await this.GetOne(new FotoDoParticipanteFilter { FotoDoParticipateId = fotodoparticipante.FotoDoParticipateId });
			var fotodoparticipanteOrchestrated = await this.DomainOrchestration(fotodoparticipante, fotodoparticipanteOld);

            if (questionToContinue)
            {
                if (this.Continue(fotodoparticipanteOrchestrated, fotodoparticipanteOld) == false)
                    return fotodoparticipanteOrchestrated;
            }

            return this.SaveWithValidation(fotodoparticipanteOrchestrated, fotodoparticipanteOld);
        }

        public override async Task<FotoDoParticipante> SavePartial(FotoDoParticipante fotodoparticipante, bool questionToContinue = false)
        {
            var fotodoparticipanteOld = await this.GetOne(new FotoDoParticipanteFilter { FotoDoParticipateId = fotodoparticipante.FotoDoParticipateId });
			var fotodoparticipanteOrchestrated = await this.DomainOrchestration(fotodoparticipante, fotodoparticipanteOld);

            if (questionToContinue)
            {
                if (this.Continue(fotodoparticipanteOrchestrated, fotodoparticipanteOld) == false)
                    return fotodoparticipanteOrchestrated;
            }

            return SaveWithOutValidation(fotodoparticipanteOrchestrated, fotodoparticipanteOld);
        }

        protected override FotoDoParticipante SaveWithOutValidation(FotoDoParticipante fotodoparticipante, FotoDoParticipante fotodoparticipanteOld)
        {
            fotodoparticipante = this.SaveDefault(fotodoparticipante, fotodoparticipanteOld);
			this._cacheHelper.ClearCache();

			if (!fotodoparticipante.IsValid())
			{
				this._validationResult = fotodoparticipante.GetDomainValidation();
				this._validationWarning = fotodoparticipante.GetDomainWarning();
				return fotodoparticipante;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return fotodoparticipante;
        }

		protected override FotoDoParticipante SaveWithValidation(FotoDoParticipante fotodoparticipante, FotoDoParticipante fotodoparticipanteOld)
        {
            if (!this.IsValid(fotodoparticipante))
				return fotodoparticipante;
            
            fotodoparticipante = this.SaveDefault(fotodoparticipante, fotodoparticipanteOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return fotodoparticipante;
        }
		
		protected virtual bool IsValid(FotoDoParticipante entity)
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

		protected virtual void Specifications(FotoDoParticipante fotodoparticipante)
        {
            this._validationResult  = this._validationResult.Merge(new FotoDoParticipanteIsSuitableValidation(this._rep).Validate(fotodoparticipante));
			this._validationWarning  = this._validationWarning.Merge(new FotoDoParticipanteIsSuitableWarning(this._rep).Validate(fotodoparticipante));
        }

        protected virtual FotoDoParticipante SaveDefault(FotoDoParticipante fotodoparticipante, FotoDoParticipante fotodoparticipanteOld)
        {
			fotodoparticipante = this.AuditDefault(fotodoparticipante, fotodoparticipanteOld);

            var isNew = fotodoparticipanteOld.IsNull();			
            if (isNew)
                fotodoparticipante = this.AddDefault(fotodoparticipante);
            else
				fotodoparticipante = this.UpdateDefault(fotodoparticipante);

            return fotodoparticipante;
        }
		
        protected virtual FotoDoParticipante AddDefault(FotoDoParticipante fotodoparticipante)
        {
            fotodoparticipante = this._rep.Add(fotodoparticipante);
            return fotodoparticipante;
        }

		protected virtual FotoDoParticipante UpdateDefault(FotoDoParticipante fotodoparticipante)
        {
            fotodoparticipante = this._rep.Update(fotodoparticipante);
            return fotodoparticipante;
        }
				
		public virtual async Task<FotoDoParticipante> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new FotoDoParticipante.FotoDoParticipanteFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<FotoDoParticipante> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new FotoDoParticipante.FotoDoParticipanteFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
