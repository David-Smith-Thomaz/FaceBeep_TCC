using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class UsuarioFilterBasicExtension
    {

        public static IQueryable<Usuario> WithBasicFilters(this IQueryable<Usuario> queryBase, UsuarioFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.UsuarioId));

            if (filters.UsuarioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UsuarioId == filters.UsuarioId);
			}
            if (filters.Login.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Login.Contains(filters.Login));
			}
            if (filters.Senha.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Senha.Contains(filters.Senha));
			}
            if (filters.Email.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Email.Contains(filters.Email));
			}
            if (filters.StatusDoUsuarioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StatusDoUsuarioId == filters.StatusDoUsuarioId);
			}
            if (filters.TipoDeUsuarioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.TipoDeUsuarioId == filters.TipoDeUsuarioId);
			}
            if (filters.ParticipanteId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ParticipanteId != null && _.ParticipanteId.Value == filters.ParticipanteId);
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