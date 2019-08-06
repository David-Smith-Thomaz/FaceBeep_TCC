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
    public class TipoDeParticipanteRepository : Repository<TipoDeParticipante>, ITipoDeParticipanteRepository
    {
        private CurrentUser _user;
        public TipoDeParticipanteRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<TipoDeParticipante> GetBySimplefilters(TipoDeParticipanteFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<TipoDeParticipante> GetById(TipoDeParticipanteFilter model)
        {
            var _tipodeparticipante = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.TipoDeParticipanteId == model.TipoDeParticipanteId));

            return _tipodeparticipante;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(TipoDeParticipanteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TipoDeParticipanteId,
				Name = _.Descricao
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(TipoDeParticipanteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TipoDeParticipanteId

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(TipoDeParticipanteFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TipoDeParticipanteId
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(TipoDeParticipanteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
               Id = _.TipoDeParticipanteId

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<TipoDeParticipante> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<TipoDeParticipante> source, FilterBase filters)
        {
			if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;

        }

        protected override IQueryable<TipoDeParticipante> MapperGetByFiltersToDomainFields(IQueryable<TipoDeParticipante> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new TipoDeParticipante
                {

                }).AsQueryable();
            }

            return result.Select(_ => (TipoDeParticipante)_).AsQueryable();

        }

        protected override TipoDeParticipante MapperGetOneToDomainFields(IQueryable<TipoDeParticipante> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new TipoDeParticipante
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<TipoDeParticipante, object>>[] DataAgregation(Expression<Func<TipoDeParticipante, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
