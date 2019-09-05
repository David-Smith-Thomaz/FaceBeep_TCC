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
    public class StatusCodigoRepository : Repository<StatusCodigo>, IStatusCodigoRepository
    {
        private CurrentUser _user;
        public StatusCodigoRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<StatusCodigo> GetBySimplefilters(StatusCodigoFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<StatusCodigo> GetById(StatusCodigoFilter model)
        {
            var _statuscodigo = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.StatusCodigoId == model.StatusCodigoId));

            return _statuscodigo;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(StatusCodigoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusCodigoId,
				Name = _.Description
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(StatusCodigoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusCodigoId

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(StatusCodigoFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusCodigoId
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(StatusCodigoFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
               Id = _.StatusCodigoId

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<StatusCodigo> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<StatusCodigo> source, FilterBase filters)
        {
			if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;

        }

        protected override IQueryable<StatusCodigo> MapperGetByFiltersToDomainFields(IQueryable<StatusCodigo> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new StatusCodigo
                {

                }).AsQueryable();
            }

            return result.Select(_ => (StatusCodigo)_).AsQueryable();

        }

        protected override StatusCodigo MapperGetOneToDomainFields(IQueryable<StatusCodigo> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new StatusCodigo
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<StatusCodigo, object>>[] DataAgregation(Expression<Func<StatusCodigo, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
