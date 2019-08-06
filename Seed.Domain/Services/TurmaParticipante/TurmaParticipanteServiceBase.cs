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
    public class TurmaParticipanteServiceBase : ServiceBase<TurmaParticipante>
    {
        protected readonly ITurmaParticipanteRepository _rep;

        public TurmaParticipanteServiceBase(ITurmaParticipanteRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<TurmaParticipante> GetOne(TurmaParticipanteFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<TurmaParticipante>> GetByFilters(TurmaParticipanteFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<TurmaParticipante>> GetByFiltersPaging(TurmaParticipanteFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(TurmaParticipante turmaparticipante)
        {
            this._rep.Remove(turmaparticipante);
        }

        public virtual Summary GetSummary(PaginateResult<TurmaParticipante> paginateResult)
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

        public override async Task<TurmaParticipante> Save(TurmaParticipante turmaparticipante, bool questionToContinue = false)
        {
			var turmaparticipanteOld = await this.GetOne(new TurmaParticipanteFilter { TurmaParticipanteId = turmaparticipante.TurmaParticipanteId });
			var turmaparticipanteOrchestrated = await this.DomainOrchestration(turmaparticipante, turmaparticipanteOld);

            if (questionToContinue)
            {
                if (this.Continue(turmaparticipanteOrchestrated, turmaparticipanteOld) == false)
                    return turmaparticipanteOrchestrated;
            }

            return this.SaveWithValidation(turmaparticipanteOrchestrated, turmaparticipanteOld);
        }

        public override async Task<TurmaParticipante> SavePartial(TurmaParticipante turmaparticipante, bool questionToContinue = false)
        {
            var turmaparticipanteOld = await this.GetOne(new TurmaParticipanteFilter { TurmaParticipanteId = turmaparticipante.TurmaParticipanteId });
			var turmaparticipanteOrchestrated = await this.DomainOrchestration(turmaparticipante, turmaparticipanteOld);

            if (questionToContinue)
            {
                if (this.Continue(turmaparticipanteOrchestrated, turmaparticipanteOld) == false)
                    return turmaparticipanteOrchestrated;
            }

            return SaveWithOutValidation(turmaparticipanteOrchestrated, turmaparticipanteOld);
        }

        protected override TurmaParticipante SaveWithOutValidation(TurmaParticipante turmaparticipante, TurmaParticipante turmaparticipanteOld)
        {
            turmaparticipante = this.SaveDefault(turmaparticipante, turmaparticipanteOld);
			this._cacheHelper.ClearCache();

			if (!turmaparticipante.IsValid())
			{
				this._validationResult = turmaparticipante.GetDomainValidation();
				this._validationWarning = turmaparticipante.GetDomainWarning();
				return turmaparticipante;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return turmaparticipante;
        }

		protected override TurmaParticipante SaveWithValidation(TurmaParticipante turmaparticipante, TurmaParticipante turmaparticipanteOld)
        {
            if (!this.IsValid(turmaparticipante))
				return turmaparticipante;
            
            turmaparticipante = this.SaveDefault(turmaparticipante, turmaparticipanteOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return turmaparticipante;
        }
		
		protected virtual bool IsValid(TurmaParticipante entity)
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

		protected virtual void Specifications(TurmaParticipante turmaparticipante)
        {
            this._validationResult  = this._validationResult.Merge(new TurmaParticipanteIsSuitableValidation(this._rep).Validate(turmaparticipante));
			this._validationWarning  = this._validationWarning.Merge(new TurmaParticipanteIsSuitableWarning(this._rep).Validate(turmaparticipante));
        }

        protected virtual TurmaParticipante SaveDefault(TurmaParticipante turmaparticipante, TurmaParticipante turmaparticipanteOld)
        {
			

            var isNew = turmaparticipanteOld.IsNull();			
            if (isNew)
                turmaparticipante = this.AddDefault(turmaparticipante);
            else
				turmaparticipante = this.UpdateDefault(turmaparticipante);

            return turmaparticipante;
        }
		
        protected virtual TurmaParticipante AddDefault(TurmaParticipante turmaparticipante)
        {
            turmaparticipante = this._rep.Add(turmaparticipante);
            return turmaparticipante;
        }

		protected virtual TurmaParticipante UpdateDefault(TurmaParticipante turmaparticipante)
        {
            turmaparticipante = this._rep.Update(turmaparticipante);
            return turmaparticipante;
        }
				
		public virtual async Task<TurmaParticipante> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new TurmaParticipante.TurmaParticipanteFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<TurmaParticipante> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new TurmaParticipante.TurmaParticipanteFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
