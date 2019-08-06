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
    public class StatusDaTurmaRepository : Repository<StatusDaTurma>, IStatusDaTurmaRepository
    {
        private CurrentUser _user;
        public StatusDaTurmaRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<StatusDaTurma> GetBySimplefilters(StatusDaTurmaFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<StatusDaTurma> GetById(StatusDaTurmaFilter model)
        {
            var _statusdaturma = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.StatusDaTurmaId == model.StatusDaTurmaId));

            return _statusdaturma;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(StatusDaTurmaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusDaTurmaId,
				Name = _.Descricao
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(StatusDaTurmaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusDaTurmaId

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(StatusDaTurmaFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusDaTurmaId
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(StatusDaTurmaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
               Id = _.StatusDaTurmaId

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<StatusDaTurma> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<StatusDaTurma> source, FilterBase filters)
        {
			if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;

        }

        protected override IQueryable<StatusDaTurma> MapperGetByFiltersToDomainFields(IQueryable<StatusDaTurma> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new StatusDaTurma
                {

                }).AsQueryable();
            }

            return result.Select(_ => (StatusDaTurma)_).AsQueryable();

        }

        protected override StatusDaTurma MapperGetOneToDomainFields(IQueryable<StatusDaTurma> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new StatusDaTurma
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<StatusDaTurma, object>>[] DataAgregation(Expression<Func<StatusDaTurma, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
