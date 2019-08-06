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
    public class StatusDoUsuarioRepository : Repository<StatusDoUsuario>, IStatusDoUsuarioRepository
    {
        private CurrentUser _user;
        public StatusDoUsuarioRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<StatusDoUsuario> GetBySimplefilters(StatusDoUsuarioFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<StatusDoUsuario> GetById(StatusDoUsuarioFilter model)
        {
            var _statusdousuario = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.StatusDoUsuarioId == model.StatusDoUsuarioId));

            return _statusdousuario;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(StatusDoUsuarioFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusDoUsuarioId,
				Name = _.Descricao
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(StatusDoUsuarioFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusDoUsuarioId

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(StatusDoUsuarioFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.StatusDoUsuarioId
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(StatusDoUsuarioFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
               Id = _.StatusDoUsuarioId

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<StatusDoUsuario> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<StatusDoUsuario> source, FilterBase filters)
        {
			if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;

        }

        protected override IQueryable<StatusDoUsuario> MapperGetByFiltersToDomainFields(IQueryable<StatusDoUsuario> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new StatusDoUsuario
                {

                }).AsQueryable();
            }

            return result.Select(_ => (StatusDoUsuario)_).AsQueryable();

        }

        protected override StatusDoUsuario MapperGetOneToDomainFields(IQueryable<StatusDoUsuario> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new StatusDoUsuario
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<StatusDoUsuario, object>>[] DataAgregation(Expression<Func<StatusDoUsuario, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
