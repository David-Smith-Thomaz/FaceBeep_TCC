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
    public class TurmaParticipanteRepository : Repository<TurmaParticipante>, ITurmaParticipanteRepository
    {
        private CurrentUser _user;
        public TurmaParticipanteRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<TurmaParticipante> GetBySimplefilters(TurmaParticipanteFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<TurmaParticipante> GetById(TurmaParticipanteFilter model)
        {
            var _turmaparticipante = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.TurmaParticipanteId == model.TurmaParticipanteId));

            return _turmaparticipante;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(TurmaParticipanteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TurmaParticipanteId,
				Name = _.TurmaParticipanteId
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(TurmaParticipanteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TurmaParticipanteId

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(TurmaParticipanteFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TurmaParticipanteId
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(TurmaParticipanteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
               Id = _.TurmaParticipanteId

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<TurmaParticipante> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<TurmaParticipante> source, FilterBase filters)
        {
			if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;

        }

        protected override IQueryable<TurmaParticipante> MapperGetByFiltersToDomainFields(IQueryable<TurmaParticipante> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new TurmaParticipante
                {

                }).AsQueryable();
            }

            return result.Select(_ => (TurmaParticipante)_).AsQueryable();

        }

        protected override TurmaParticipante MapperGetOneToDomainFields(IQueryable<TurmaParticipante> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new TurmaParticipante
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<TurmaParticipante, object>>[] DataAgregation(Expression<Func<TurmaParticipante, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
