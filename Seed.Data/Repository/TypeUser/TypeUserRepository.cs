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
    public class TypeUserRepository : Repository<TypeUser>, ITypeUserRepository
    {
        private CurrentUser _user;
        public TypeUserRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<TypeUser> GetBySimplefilters(TypeUserFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<TypeUser> GetById(TypeUserFilter model)
        {
            var _typeuser = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.TypeUserId == model.TypeUserId));

            return _typeuser;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(TypeUserFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TypeUserId,
				Name = _.Description
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(TypeUserFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TypeUserId

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(TypeUserFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TypeUserId
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(TypeUserFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
               Id = _.TypeUserId

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<TypeUser> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<TypeUser> source, FilterBase filters)
        {
			if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;

        }

        protected override IQueryable<TypeUser> MapperGetByFiltersToDomainFields(IQueryable<TypeUser> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new TypeUser
                {

                }).AsQueryable();
            }

            return result.Select(_ => (TypeUser)_).AsQueryable();

        }

        protected override TypeUser MapperGetOneToDomainFields(IQueryable<TypeUser> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new TypeUser
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<TypeUser, object>>[] DataAgregation(Expression<Func<TypeUser, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
