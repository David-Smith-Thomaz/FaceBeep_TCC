using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class StatusDaTurmaFilterBasicExtension
    {

        public static IQueryable<StatusDaTurma> WithBasicFilters(this IQueryable<StatusDaTurma> queryBase, StatusDaTurmaFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.StatusDaTurmaId));

            if (filters.StatusDaTurmaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StatusDaTurmaId == filters.StatusDaTurmaId);
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
			}


            return queryFilter;
        }

		
    }
}