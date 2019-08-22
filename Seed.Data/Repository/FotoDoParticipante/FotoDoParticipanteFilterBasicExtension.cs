using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class FotoDoParticipanteFilterBasicExtension
    {

        public static IQueryable<FotoDoParticipante> WithBasicFilters(this IQueryable<FotoDoParticipante> queryBase, FotoDoParticipanteFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.FotoDoParticipateId));

            if (filters.FotoDoParticipateId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.FotoDoParticipateId == filters.FotoDoParticipateId);
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
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



            return queryFilter;
        }

		
    }
}