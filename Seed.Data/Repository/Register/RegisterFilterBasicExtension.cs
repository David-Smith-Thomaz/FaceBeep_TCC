using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class RegisterFilterBasicExtension
    {

        public static IQueryable<Register> WithBasicFilters(this IQueryable<Register> queryBase, RegisterFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.RegisterId));

            if (filters.RegisterId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.RegisterId == filters.RegisterId);
			}
            if (filters.StatusRegisterId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StatusRegisterId == filters.StatusRegisterId);
			}
            if (filters.ParticipantId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ParticipantId == filters.ParticipantId);
			}
            if (filters.Description.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Description.Contains(filters.Description));
			}
            if (filters.EnterDate.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=> _.EnterDate >= filters.EnterDate.AddHours(-filters.EnterDate.Hour).AddMinutes(-filters.EnterDate.Minute).AddSeconds(-filters.EnterDate.Second) && _.EnterDate <= filters.EnterDate.AddDays(1).AddHours(-filters.EnterDate.Hour).AddMinutes(-filters.EnterDate.Minute).AddSeconds(-filters.EnterDate.Second));
			}
            if (filters.EnterDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.EnterDate >= filters.EnterDateStart );
			}
            if (filters.EnterDateEnd.IsSent()) 
			{ 
				filters.EnterDateEnd = filters.EnterDateEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.EnterDate  <= filters.EnterDateEnd);
			}

            if (filters.ExitDate.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=> _.ExitDate >= filters.ExitDate.AddHours(-filters.ExitDate.Hour).AddMinutes(-filters.ExitDate.Minute).AddSeconds(-filters.ExitDate.Second) && _.ExitDate <= filters.ExitDate.AddDays(1).AddHours(-filters.ExitDate.Hour).AddMinutes(-filters.ExitDate.Minute).AddSeconds(-filters.ExitDate.Second));
			}
            if (filters.ExitDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ExitDate >= filters.ExitDateStart );
			}
            if (filters.ExitDateEnd.IsSent()) 
			{ 
				filters.ExitDateEnd = filters.ExitDateEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.ExitDate  <= filters.ExitDateEnd);
			}



            return queryFilter;
        }

		
    }
}