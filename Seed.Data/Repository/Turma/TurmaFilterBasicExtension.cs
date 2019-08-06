using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class TurmaFilterBasicExtension
    {

        public static IQueryable<Turma> WithBasicFilters(this IQueryable<Turma> queryBase, TurmaFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.TurmaId));

            if (filters.TurmaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.TurmaId == filters.TurmaId);
			}
            if (filters.CodigoDaTurma.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.CodigoDaTurma.Contains(filters.CodigoDaTurma));
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
			}
            if (filters.DataInicio.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=> _.DataInicio >= filters.DataInicio.AddHours(-filters.DataInicio.Hour).AddMinutes(-filters.DataInicio.Minute).AddSeconds(-filters.DataInicio.Second) && _.DataInicio <= filters.DataInicio.AddDays(1).AddHours(-filters.DataInicio.Hour).AddMinutes(-filters.DataInicio.Minute).AddSeconds(-filters.DataInicio.Second));
			}
            if (filters.DataInicioStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.DataInicio >= filters.DataInicioStart );
			}
            if (filters.DataInicioEnd.IsSent()) 
			{ 
				filters.DataInicioEnd = filters.DataInicioEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.DataInicio  <= filters.DataInicioEnd);
			}

            if (filters.DataFim.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=> _.DataFim >= filters.DataFim.AddHours(-filters.DataFim.Hour).AddMinutes(-filters.DataFim.Minute).AddSeconds(-filters.DataFim.Second) && _.DataFim <= filters.DataFim.AddDays(1).AddHours(-filters.DataFim.Hour).AddMinutes(-filters.DataFim.Minute).AddSeconds(-filters.DataFim.Second));
			}
            if (filters.DataFimStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.DataFim >= filters.DataFimStart );
			}
            if (filters.DataFimEnd.IsSent()) 
			{ 
				filters.DataFimEnd = filters.DataFimEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.DataFim  <= filters.DataFimEnd);
			}

            if (filters.AdmTurmaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.AdmTurmaId == filters.AdmTurmaId);
			}
            if (filters.StatusDaTurmaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StatusDaTurmaId == filters.StatusDaTurmaId);
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