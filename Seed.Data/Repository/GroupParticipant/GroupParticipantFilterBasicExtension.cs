using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class GroupParticipantFilterBasicExtension
    {

        public static IQueryable<GroupParticipant> WithBasicFilters(this IQueryable<GroupParticipant> queryBase, GroupParticipantFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.GroupParticipantId));

            if (filters.GroupParticipantId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.GroupParticipantId == filters.GroupParticipantId);
			}
            if (filters.GroupName.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.GroupName.Contains(filters.GroupName));
			}
            if (filters.StartDatePeriod.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=> _.StartDatePeriod >= filters.StartDatePeriod.AddHours(-filters.StartDatePeriod.Hour).AddMinutes(-filters.StartDatePeriod.Minute).AddSeconds(-filters.StartDatePeriod.Second) && _.StartDatePeriod <= filters.StartDatePeriod.AddDays(1).AddHours(-filters.StartDatePeriod.Hour).AddMinutes(-filters.StartDatePeriod.Minute).AddSeconds(-filters.StartDatePeriod.Second));
			}
            if (filters.StartDatePeriodStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StartDatePeriod >= filters.StartDatePeriodStart );
			}
            if (filters.StartDatePeriodEnd.IsSent()) 
			{ 
				filters.StartDatePeriodEnd = filters.StartDatePeriodEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.StartDatePeriod  <= filters.StartDatePeriodEnd);
			}

            if (filters.EndDatePeriod.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=> _.EndDatePeriod >= filters.EndDatePeriod.AddHours(-filters.EndDatePeriod.Hour).AddMinutes(-filters.EndDatePeriod.Minute).AddSeconds(-filters.EndDatePeriod.Second) && _.EndDatePeriod <= filters.EndDatePeriod.AddDays(1).AddHours(-filters.EndDatePeriod.Hour).AddMinutes(-filters.EndDatePeriod.Minute).AddSeconds(-filters.EndDatePeriod.Second));
			}
            if (filters.EndDatePeriodStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.EndDatePeriod >= filters.EndDatePeriodStart );
			}
            if (filters.EndDatePeriodEnd.IsSent()) 
			{ 
				filters.EndDatePeriodEnd = filters.EndDatePeriodEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.EndDatePeriod  <= filters.EndDatePeriodEnd);
			}

            if (filters.Active.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Active == filters.Active);
			}


            return queryFilter;
        }

		
    }
}