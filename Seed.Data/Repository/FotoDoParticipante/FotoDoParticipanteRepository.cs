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
    public class FotoDoParticipanteRepository : Repository<FotoDoParticipante>, IFotoDoParticipanteRepository
    {
        private CurrentUser _user;
        public FotoDoParticipanteRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<FotoDoParticipante> GetBySimplefilters(FotoDoParticipanteFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<FotoDoParticipante> GetById(FotoDoParticipanteFilter model)
        {
            var _fotodoparticipante = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.FotoDoParticipateId == model.FotoDoParticipateId));

            return _fotodoparticipante;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(FotoDoParticipanteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.FotoDoParticipateId,
				Name = _.UserAlterDate
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(FotoDoParticipanteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.FotoDoParticipateId

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(FotoDoParticipanteFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.FotoDoParticipateId
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(FotoDoParticipanteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
               Id = _.FotoDoParticipateId

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<FotoDoParticipante> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<FotoDoParticipante> source, FilterBase filters)
        {
			if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;

        }

        protected override IQueryable<FotoDoParticipante> MapperGetByFiltersToDomainFields(IQueryable<FotoDoParticipante> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new FotoDoParticipante
                {

                }).AsQueryable();
            }

            return result.Select(_ => (FotoDoParticipante)_).AsQueryable();

        }

        protected override FotoDoParticipante MapperGetOneToDomainFields(IQueryable<FotoDoParticipante> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new FotoDoParticipante
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<FotoDoParticipante, object>>[] DataAgregation(Expression<Func<FotoDoParticipante, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
