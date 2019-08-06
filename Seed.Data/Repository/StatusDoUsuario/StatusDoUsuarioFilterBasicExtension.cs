using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class StatusDoUsuarioFilterBasicExtension
    {

        public static IQueryable<StatusDoUsuario> WithBasicFilters(this IQueryable<StatusDoUsuario> queryBase, StatusDoUsuarioFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.StatusDoUsuarioId));

            if (filters.StatusDoUsuarioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StatusDoUsuarioId == filters.StatusDoUsuarioId);
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
			}


            return queryFilter;
        }

		
    }
}