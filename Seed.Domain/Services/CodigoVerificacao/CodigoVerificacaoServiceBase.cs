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
    public class CodigoVerificacaoServiceBase : ServiceBase<CodigoVerificacao>
    {
        protected readonly ICodigoVerificacaoRepository _rep;

        public CodigoVerificacaoServiceBase(ICodigoVerificacaoRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<CodigoVerificacao> GetOne(CodigoVerificacaoFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<CodigoVerificacao>> GetByFilters(CodigoVerificacaoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<CodigoVerificacao>> GetByFiltersPaging(CodigoVerificacaoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(CodigoVerificacao codigoverificacao)
        {
            this._rep.Remove(codigoverificacao);
        }

        public virtual Summary GetSummary(PaginateResult<CodigoVerificacao> paginateResult)
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

        public override async Task<CodigoVerificacao> Save(CodigoVerificacao codigoverificacao, bool questionToContinue = false)
        {
			var codigoverificacaoOld = await this.GetOne(new CodigoVerificacaoFilter { CodigoVerificacaoId = codigoverificacao.CodigoVerificacaoId });
			var codigoverificacaoOrchestrated = await this.DomainOrchestration(codigoverificacao, codigoverificacaoOld);

            if (questionToContinue)
            {
                if (this.Continue(codigoverificacaoOrchestrated, codigoverificacaoOld) == false)
                    return codigoverificacaoOrchestrated;
            }

            return this.SaveWithValidation(codigoverificacaoOrchestrated, codigoverificacaoOld);
        }

        public override async Task<CodigoVerificacao> SavePartial(CodigoVerificacao codigoverificacao, bool questionToContinue = false)
        {
            var codigoverificacaoOld = await this.GetOne(new CodigoVerificacaoFilter { CodigoVerificacaoId = codigoverificacao.CodigoVerificacaoId });
			var codigoverificacaoOrchestrated = await this.DomainOrchestration(codigoverificacao, codigoverificacaoOld);

            if (questionToContinue)
            {
                if (this.Continue(codigoverificacaoOrchestrated, codigoverificacaoOld) == false)
                    return codigoverificacaoOrchestrated;
            }

            return SaveWithOutValidation(codigoverificacaoOrchestrated, codigoverificacaoOld);
        }

        protected override CodigoVerificacao SaveWithOutValidation(CodigoVerificacao codigoverificacao, CodigoVerificacao codigoverificacaoOld)
        {
            codigoverificacao = this.SaveDefault(codigoverificacao, codigoverificacaoOld);
			this._cacheHelper.ClearCache();

			if (!codigoverificacao.IsValid())
			{
				this._validationResult = codigoverificacao.GetDomainValidation();
				this._validationWarning = codigoverificacao.GetDomainWarning();
				return codigoverificacao;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return codigoverificacao;
        }

		protected override CodigoVerificacao SaveWithValidation(CodigoVerificacao codigoverificacao, CodigoVerificacao codigoverificacaoOld)
        {
            if (!this.IsValid(codigoverificacao))
				return codigoverificacao;
            
            codigoverificacao = this.SaveDefault(codigoverificacao, codigoverificacaoOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return codigoverificacao;
        }
		
		protected virtual bool IsValid(CodigoVerificacao entity)
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

		protected virtual void Specifications(CodigoVerificacao codigoverificacao)
        {
            this._validationResult  = this._validationResult.Merge(new CodigoVerificacaoIsSuitableValidation(this._rep).Validate(codigoverificacao));
			this._validationWarning  = this._validationWarning.Merge(new CodigoVerificacaoIsSuitableWarning(this._rep).Validate(codigoverificacao));
        }

        protected virtual CodigoVerificacao SaveDefault(CodigoVerificacao codigoverificacao, CodigoVerificacao codigoverificacaoOld)
        {
			

            var isNew = codigoverificacaoOld.IsNull();			
            if (isNew)
                codigoverificacao = this.AddDefault(codigoverificacao);
            else
				codigoverificacao = this.UpdateDefault(codigoverificacao);

            return codigoverificacao;
        }
		
        protected virtual CodigoVerificacao AddDefault(CodigoVerificacao codigoverificacao)
        {
            codigoverificacao = this._rep.Add(codigoverificacao);
            return codigoverificacao;
        }

		protected virtual CodigoVerificacao UpdateDefault(CodigoVerificacao codigoverificacao)
        {
            codigoverificacao = this._rep.Update(codigoverificacao);
            return codigoverificacao;
        }
				
		public virtual async Task<CodigoVerificacao> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new CodigoVerificacao.CodigoVerificacaoFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<CodigoVerificacao> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new CodigoVerificacao.CodigoVerificacaoFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
