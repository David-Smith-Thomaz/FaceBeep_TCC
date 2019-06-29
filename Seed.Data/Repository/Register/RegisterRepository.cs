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
    public class RegisterRepository : Repository<Register>, IRegisterRepository
    {
        private CurrentUser _user;
        public RegisterRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<Register> GetBySimplefilters(RegisterFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<Register> GetById(RegisterFilter model)
        {
            var _register = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               );

            return _register;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(RegisterFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.Description,
				Name = _.Description
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(RegisterFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.Description

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(RegisterFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.Description
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(RegisterFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
               Id = _.Description

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Register> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Register> source, FilterBase filters)
        {
			if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;

        }

        protected override IQueryable<Register> MapperGetByFiltersToDomainFields(IQueryable<Register> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Register
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Register)_).AsQueryable();

        }

        protected override Register MapperGetOneToDomainFields(IQueryable<Register> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Register
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<Register, object>>[] DataAgregation(Expression<Func<Register, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
