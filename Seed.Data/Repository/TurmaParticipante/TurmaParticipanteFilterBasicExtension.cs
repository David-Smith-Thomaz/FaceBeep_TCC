using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class TurmaParticipanteFilterBasicExtension
    {

        public static IQueryable<TurmaParticipante> WithBasicFilters(this IQueryable<TurmaParticipante> queryBase, TurmaParticipanteFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.TurmaParticipanteId));

            if (filters.TurmaParticipanteId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.TurmaParticipanteId == filters.TurmaParticipanteId);
			}
            if (filters.ParticipanteId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ParticipanteId == filters.ParticipanteId);
			}
            if (filters.TurmaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.TurmaId == filters.TurmaId);
			}


            return queryFilter;
        }

		
    }
}