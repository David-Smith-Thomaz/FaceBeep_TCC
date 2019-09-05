using Common.Domain.Base;
using Common.Orm;
using Seed.Data.Context;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using Common.Domain.Model;

namespace Seed.Data.Repository
{
    public class CodigoVerificacaoRepository : Repository<CodigoVerificacao>, ICodigoVerificacaoRepository
    {
        private CurrentUser _user;
        public CodigoVerificacaoRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<CodigoVerificacao> GetBySimplefilters(CodigoVerificacaoFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<CodigoVerificacao> GetById(CodigoVerificacaoFilter model)
        {
            var _codigoverificacao = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.CodigoVerificacaoId == model.CodigoVerificacaoId));

            return _codigoverificacao;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(CodigoVerificacaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.CodigoVerificacaoId,
				Name = _.Codigo
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(CodigoVerificacaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.CodigoVerificacaoId

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(CodigoVerificacaoFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.CodigoVerificacaoId
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(CodigoVerificacaoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
               Id = _.CodigoVerificacaoId

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<CodigoVerificacao> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<CodigoVerificacao> source, FilterBase filters)
        {
			if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;

        }

        protected override IQueryable<CodigoVerificacao> MapperGetByFiltersToDomainFields(IQueryable<CodigoVerificacao> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new CodigoVerificacao
                {

                }).AsQueryable();
            }

            return result.Select(_ => (CodigoVerificacao)_).AsQueryable();

        }

        protected override CodigoVerificacao MapperGetOneToDomainFields(IQueryable<CodigoVerificacao> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new CodigoVerificacao
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<CodigoVerificacao, object>>[] DataAgregation(Expression<Func<CodigoVerificacao, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
