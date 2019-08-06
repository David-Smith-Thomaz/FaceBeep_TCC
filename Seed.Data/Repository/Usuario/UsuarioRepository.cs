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
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private CurrentUser _user;
        public UsuarioRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<Usuario> GetBySimplefilters(UsuarioFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<Usuario> GetById(UsuarioFilter model)
        {
            var _usuario = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.UsuarioId == model.UsuarioId));

            return _usuario;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(UsuarioFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.UsuarioId,
				Name = _.Login
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(UsuarioFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.UsuarioId

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(UsuarioFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.UsuarioId
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(UsuarioFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
               Id = _.UsuarioId

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Usuario> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Usuario> source, FilterBase filters)
        {
			if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;

        }

        protected override IQueryable<Usuario> MapperGetByFiltersToDomainFields(IQueryable<Usuario> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Usuario
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Usuario)_).AsQueryable();

        }

        protected override Usuario MapperGetOneToDomainFields(IQueryable<Usuario> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Usuario
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<Usuario, object>>[] DataAgregation(Expression<Func<Usuario, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
