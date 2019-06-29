using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class TypeUserFilterBasicExtension
    {

        public static IQueryable<TypeUser> WithBasicFilters(this IQueryable<TypeUser> queryBase, TypeUserFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.TypeUserId));

            if (filters.TypeUserId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.TypeUserId == filters.TypeUserId);
			}
            if (filters.Description.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Description.Contains(filters.Description));
			}


            return queryFilter;
        }

		
    }
}