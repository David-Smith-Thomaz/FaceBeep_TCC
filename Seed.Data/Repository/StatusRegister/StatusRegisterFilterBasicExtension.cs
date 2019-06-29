using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class StatusRegisterFilterBasicExtension
    {

        public static IQueryable<StatusRegister> WithBasicFilters(this IQueryable<StatusRegister> queryBase, StatusRegisterFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.StatusRegisterId));

            if (filters.StatusRegisterId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StatusRegisterId == filters.StatusRegisterId);
			}
            if (filters.Description.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Description.Contains(filters.Description));
			}


            return queryFilter;
        }

		
    }
}