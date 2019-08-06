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
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        private CurrentUser _user;
        public TurmaRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<Turma> GetBySimplefilters(TurmaFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<Turma> GetById(TurmaFilter model)
        {
            var _turma = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.TurmaId == model.TurmaId));

            return _turma;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(TurmaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TurmaId,
				Name = _.CodigoDaTurma
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(TurmaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TurmaId

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(TurmaFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TurmaId
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(TurmaFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
               Id = _.TurmaId

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Turma> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Turma> source, FilterBase filters)
        {
			if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;

        }

        protected override IQueryable<Turma> MapperGetByFiltersToDomainFields(IQueryable<Turma> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Turma
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Turma)_).AsQueryable();

        }

        protected override Turma MapperGetOneToDomainFields(IQueryable<Turma> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Turma
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<Turma, object>>[] DataAgregation(Expression<Func<Turma, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
