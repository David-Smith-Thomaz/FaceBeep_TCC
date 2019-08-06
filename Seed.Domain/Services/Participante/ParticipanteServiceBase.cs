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
    public class ParticipanteServiceBase : ServiceBase<Participante>
    {
        protected readonly IParticipanteRepository _rep;

        public ParticipanteServiceBase(IParticipanteRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<Participante> GetOne(ParticipanteFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Participante>> GetByFilters(ParticipanteFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Participante>> GetByFiltersPaging(ParticipanteFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(Participante participante)
        {
            this._rep.Remove(participante);
        }

        public virtual Summary GetSummary(PaginateResult<Participante> paginateResult)
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

        public override async Task<Participante> Save(Participante participante, bool questionToContinue = false)
        {
			var participanteOld = await this.GetOne(new ParticipanteFilter { ParticipanteId = participante.ParticipanteId });
			var participanteOrchestrated = await this.DomainOrchestration(participante, participanteOld);

            if (questionToContinue)
            {
                if (this.Continue(participanteOrchestrated, participanteOld) == false)
                    return participanteOrchestrated;
            }

            return this.SaveWithValidation(participanteOrchestrated, participanteOld);
        }

        public override async Task<Participante> SavePartial(Participante participante, bool questionToContinue = false)
        {
            var participanteOld = await this.GetOne(new ParticipanteFilter { ParticipanteId = participante.ParticipanteId });
			var participanteOrchestrated = await this.DomainOrchestration(participante, participanteOld);

            if (questionToContinue)
            {
                if (this.Continue(participanteOrchestrated, participanteOld) == false)
                    return participanteOrchestrated;
            }

            return SaveWithOutValidation(participanteOrchestrated, participanteOld);
        }

        protected override Participante SaveWithOutValidation(Participante participante, Participante participanteOld)
        {
            participante = this.SaveDefault(participante, participanteOld);
			this._cacheHelper.ClearCache();

			if (!participante.IsValid())
			{
				this._validationResult = participante.GetDomainValidation();
				this._validationWarning = participante.GetDomainWarning();
				return participante;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return participante;
        }

		protected override Participante SaveWithValidation(Participante participante, Participante participanteOld)
        {
            if (!this.IsValid(participante))
				return participante;
            
            participante = this.SaveDefault(participante, participanteOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return participante;
        }
		
		protected virtual bool IsValid(Participante entity)
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

		protected virtual void Specifications(Participante participante)
        {
            this._validationResult  = this._validationResult.Merge(new ParticipanteIsSuitableValidation(this._rep).Validate(participante));
			this._validationWarning  = this._validationWarning.Merge(new ParticipanteIsSuitableWarning(this._rep).Validate(participante));
        }

        protected virtual Participante SaveDefault(Participante participante, Participante participanteOld)
        {
			participante = this.AuditDefault(participante, participanteOld);

            var isNew = participanteOld.IsNull();			
            if (isNew)
                participante = this.AddDefault(participante);
            else
				participante = this.UpdateDefault(participante);

            return participante;
        }
		
        protected virtual Participante AddDefault(Participante participante)
        {
            participante = this._rep.Add(participante);
            return participante;
        }

		protected virtual Participante UpdateDefault(Participante participante)
        {
            participante = this._rep.Update(participante);
            return participante;
        }
				
		public virtual async Task<Participante> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Participante.ParticipanteFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<Participante> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Participante.ParticipanteFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
