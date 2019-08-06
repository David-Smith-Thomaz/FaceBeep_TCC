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
    public class TipoDeUsuarioRepository : Repository<TipoDeUsuario>, ITipoDeUsuarioRepository
    {
        private CurrentUser _user;
        public TipoDeUsuarioRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<TipoDeUsuario> GetBySimplefilters(TipoDeUsuarioFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<TipoDeUsuario> GetById(TipoDeUsuarioFilter model)
        {
            var _tipodeusuario = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.TipoDeUsuarioId == model.TipoDeUsuarioId));

            return _tipodeusuario;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(TipoDeUsuarioFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TipoDeUsuarioId,
				Name = _.Descricao
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(TipoDeUsuarioFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TipoDeUsuarioId

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(TipoDeUsuarioFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TipoDeUsuarioId
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(TipoDeUsuarioFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
               Id = _.TipoDeUsuarioId

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<TipoDeUsuario> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<TipoDeUsuario> source, FilterBase filters)
        {
			if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;

        }

        protected override IQueryable<TipoDeUsuario> MapperGetByFiltersToDomainFields(IQueryable<TipoDeUsuario> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new TipoDeUsuario
                {

                }).AsQueryable();
            }

            return result.Select(_ => (TipoDeUsuario)_).AsQueryable();

        }

        protected override TipoDeUsuario MapperGetOneToDomainFields(IQueryable<TipoDeUsuario> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new TipoDeUsuario
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<TipoDeUsuario, object>>[] DataAgregation(Expression<Func<TipoDeUsuario, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
