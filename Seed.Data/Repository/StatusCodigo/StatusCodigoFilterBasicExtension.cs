using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class StatusCodigoFilterBasicExtension
    {

        public static IQueryable<StatusCodigo> WithBasicFilters(this IQueryable<StatusCodigo> queryBase, StatusCodigoFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.StatusCodigoId));

            if (filters.StatusCodigoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StatusCodigoId == filters.StatusCodigoId);
			}
            if (filters.Description.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Description.Contains(filters.Description));
			}


            return queryFilter;
        }

		
    }
}