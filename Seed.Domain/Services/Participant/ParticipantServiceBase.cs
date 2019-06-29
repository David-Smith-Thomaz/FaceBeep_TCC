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
    public class ParticipantServiceBase : ServiceBase<Participant>
    {
        protected readonly IParticipantRepository _rep;

        public ParticipantServiceBase(IParticipantRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<Participant> GetOne(ParticipantFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Participant>> GetByFilters(ParticipantFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Participant>> GetByFiltersPaging(ParticipantFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(Participant participant)
        {
            this._rep.Remove(participant);
        }

        public virtual Summary GetSummary(PaginateResult<Participant> paginateResult)
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

        public override async Task<Participant> Save(Participant participant, bool questionToContinue = false)
        {
			var participantOld = await this.GetOne(new ParticipantFilter { ParticipantId = participant.ParticipantId });
			var participantOrchestrated = await this.DomainOrchestration(participant, participantOld);

            if (questionToContinue)
            {
                if (this.Continue(participantOrchestrated, participantOld) == false)
                    return participantOrchestrated;
            }

            return this.SaveWithValidation(participantOrchestrated, participantOld);
        }

        public override async Task<Participant> SavePartial(Participant participant, bool questionToContinue = false)
        {
            var participantOld = await this.GetOne(new ParticipantFilter { ParticipantId = participant.ParticipantId });
			var participantOrchestrated = await this.DomainOrchestration(participant, participantOld);

            if (questionToContinue)
            {
                if (this.Continue(participantOrchestrated, participantOld) == false)
                    return participantOrchestrated;
            }

            return SaveWithOutValidation(participantOrchestrated, participantOld);
        }

        protected override Participant SaveWithOutValidation(Participant participant, Participant participantOld)
        {
            participant = this.SaveDefault(participant, participantOld);
			this._cacheHelper.ClearCache();

			if (!participant.IsValid())
			{
				this._validationResult = participant.GetDomainValidation();
				this._validationWarning = participant.GetDomainWarning();
				return participant;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return participant;
        }

		protected override Participant SaveWithValidation(Participant participant, Participant participantOld)
        {
            if (!this.IsValid(participant))
				return participant;
            
            participant = this.SaveDefault(participant, participantOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return participant;
        }
		
		protected virtual bool IsValid(Participant entity)
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

		protected virtual void Specifications(Participant participant)
        {
            this._validationResult  = this._validationResult.Merge(new ParticipantIsSuitableValidation(this._rep).Validate(participant));
			this._validationWarning  = this._validationWarning.Merge(new ParticipantIsSuitableWarning(this._rep).Validate(participant));
        }

        protected virtual Participant SaveDefault(Participant participant, Participant participantOld)
        {
			participant = this.AuditDefault(participant, participantOld);

            var isNew = participantOld.IsNull();			
            if (isNew)
                participant = this.AddDefault(participant);
            else
				participant = this.UpdateDefault(participant);

            return participant;
        }
		
        protected virtual Participant AddDefault(Participant participant)
        {
            participant = this._rep.Add(participant);
            return participant;
        }

		protected virtual Participant UpdateDefault(Participant participant)
        {
            participant = this._rep.Update(participant);
            return participant;
        }
				
		public virtual async Task<Participant> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Participant.ParticipantFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<Participant> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Participant.ParticipantFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
