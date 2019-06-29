using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class UserFilterBasicExtension
    {

        public static IQueryable<User> WithBasicFilters(this IQueryable<User> queryBase, UserFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.UserId));

            if (filters.UserId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserId == filters.UserId);
			}
            if (filters.StatusUserId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StatusUserId == filters.StatusUserId);
			}
            if (filters.TypeUserId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.TypeUserId == filters.TypeUserId);
			}
            if (filters.Login.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Login.Contains(filters.Login));
			}
            if (filters.Password.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Password.Contains(filters.Password));
			}
            if (filters.UserCreateId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserCreateId == filters.UserCreateId);
			}
            if (filters.UserCreateDate.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=> _.UserCreateDate >= filters.UserCreateDate.AddHours(-filters.UserCreateDate.Hour).AddMinutes(-filters.UserCreateDate.Minute).AddSeconds(-filters.UserCreateDate.Second) && _.UserCreateDate <= filters.UserCreateDate.AddDays(1).AddHours(-filters.UserCreateDate.Hour).AddMinutes(-filters.UserCreateDate.Minute).AddSeconds(-filters.UserCreateDate.Second));
			}
            if (filters.UserCreateDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserCreateDate >= filters.UserCreateDateStart );
			}
            if (filters.UserCreateDateEnd.IsSent()) 
			{ 
				filters.UserCreateDateEnd = filters.UserCreateDateEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.UserCreateDate  <= filters.UserCreateDateEnd);
			}

            if (filters.UserAlterId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserAlterId != null && _.UserAlterId.Value == filters.UserAlterId);
			}
            if (filters.UserAlterDate.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=> _.UserAlterDate != null && _.UserAlterDate >= filters.UserAlterDate.Value.AddHours(-filters.UserAlterDate.Value.Hour).AddMinutes(-filters.UserAlterDate.Value.Minute).AddSeconds(-filters.UserAlterDate.Value.Second) && _.UserAlterDate <= filters.UserAlterDate.Value.AddDays(1).AddHours(-filters.UserAlterDate.Value.Hour).AddMinutes(-filters.UserAlterDate.Value.Minute).AddSeconds(-filters.UserAlterDate.Value.Second));
			}
            if (filters.UserAlterDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserAlterDate != null && _.UserAlterDate.Value >= filters.UserAlterDateStart.Value);
			}
            if (filters.UserAlterDateEnd.IsSent()) 
			{ 
				filters.UserAlterDateEnd = filters.UserAlterDateEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.UserAlterDate != null &&  _.UserAlterDate.Value <= filters.UserAlterDateEnd);
			}



            return queryFilter;
        }

		
    }
}