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
    public class GroupParticipantRepository : Repository<GroupParticipant>, IGroupParticipantRepository
    {
        private CurrentUser _user;
        public GroupParticipantRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<GroupParticipant> GetBySimplefilters(GroupParticipantFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<GroupParticipant> GetById(GroupParticipantFilter model)
        {
            var _groupparticipant = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.GroupParticipantId == model.GroupParticipantId));

            return _groupparticipant;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(GroupParticipantFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.GroupParticipantId,
				Name = _.GroupName
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(GroupParticipantFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.GroupParticipantId

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(GroupParticipantFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.GroupParticipantId
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(GroupParticipantFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
               Id = _.GroupParticipantId

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<GroupParticipant> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<GroupParticipant> source, FilterBase filters)
        {
			if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;

        }

        protected override IQueryable<GroupParticipant> MapperGetByFiltersToDomainFields(IQueryable<GroupParticipant> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new GroupParticipant
                {

                }).AsQueryable();
            }

            return result.Select(_ => (GroupParticipant)_).AsQueryable();

        }

        protected override GroupParticipant MapperGetOneToDomainFields(IQueryable<GroupParticipant> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new GroupParticipant
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<GroupParticipant, object>>[] DataAgregation(Expression<Func<GroupParticipant, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
