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
    public class StatusRegisterRepository : Repository<StatusRegister>, IStatusRegisterRepository
    {
        private CurrentUser _user;
        public StatusRegisterRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<StatusRegister> GetBySimplefilters(StatusRegisterFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<StatusRegister> GetById(StatusRegisterFilter model)
        {
            var _statusregister = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.StatusRegisterId == model.StatusRegisterId));

            return _statusregister;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(StatusRegisterFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusRegisterId,
				Name = _.Description
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(StatusRegisterFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusRegisterId

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(StatusRegisterFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusRegisterId
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(StatusRegisterFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
               Id = _.StatusRegisterId

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<StatusRegister> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<StatusRegister> source, FilterBase filters)
        {
			if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;

        }

        protected override IQueryable<StatusRegister> MapperGetByFiltersToDomainFields(IQueryable<StatusRegister> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new StatusRegister
                {

                }).AsQueryable();
            }

            return result.Select(_ => (StatusRegister)_).AsQueryable();

        }

        protected override StatusRegister MapperGetOneToDomainFields(IQueryable<StatusRegister> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new StatusRegister
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<StatusRegister, object>>[] DataAgregation(Expression<Func<StatusRegister, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
