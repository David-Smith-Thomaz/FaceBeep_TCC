using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class TipoDeUsuarioFilterBasicExtension
    {

        public static IQueryable<TipoDeUsuario> WithBasicFilters(this IQueryable<TipoDeUsuario> queryBase, TipoDeUsuarioFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.TipoDeUsuarioId));

            if (filters.TipoDeUsuarioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.TipoDeUsuarioId == filters.TipoDeUsuarioId);
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
			}


            return queryFilter;
        }

		
    }
}