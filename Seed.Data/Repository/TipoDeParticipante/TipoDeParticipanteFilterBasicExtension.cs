using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class TipoDeParticipanteFilterBasicExtension
    {

        public static IQueryable<TipoDeParticipante> WithBasicFilters(this IQueryable<TipoDeParticipante> queryBase, TipoDeParticipanteFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.TipoDeParticipanteId));

            if (filters.TipoDeParticipanteId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.TipoDeParticipanteId == filters.TipoDeParticipanteId);
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
			}


            return queryFilter;
        }

		
    }
}