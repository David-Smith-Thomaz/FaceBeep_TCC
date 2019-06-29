using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class StatusUserFilterBasicExtension
    {

        public static IQueryable<StatusUser> WithBasicFilters(this IQueryable<StatusUser> queryBase, StatusUserFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.StatusUserId));

            if (filters.StatusUserId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StatusUserId == filters.StatusUserId);
			}
            if (filters.Description.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Description.Contains(filters.Description));
			}


            return queryFilter;
        }

		
    }
}