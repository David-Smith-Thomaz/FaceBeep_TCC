using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class CodigoVerificacaoFilterBasicExtension
    {

        public static IQueryable<CodigoVerificacao> WithBasicFilters(this IQueryable<CodigoVerificacao> queryBase, CodigoVerificacaoFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.CodigoVerificacaoId));

            if (filters.CodigoVerificacaoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.CodigoVerificacaoId == filters.CodigoVerificacaoId);
			}
            if (filters.ParticipanteId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ParticipanteId == filters.ParticipanteId);
			}
            if (filters.Codigo.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Codigo == filters.Codigo);
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

            if (filters.statusCodigoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.statusCodigoId == filters.statusCodigoId);
			}


            return queryFilter;
        }

		
    }
}