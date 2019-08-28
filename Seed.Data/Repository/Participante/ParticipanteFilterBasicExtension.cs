using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class ParticipanteFilterBasicExtension
    {

        public static IQueryable<Participante> WithBasicFilters(this IQueryable<Participante> queryBase, ParticipanteFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.ParticipanteId));

            if (filters.ParticipanteId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ParticipanteId == filters.ParticipanteId);
			}
            if (filters.UsuarioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UsuarioId == filters.UsuarioId);
			}
            if (filters.CodigoADM.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.CodigoADM == filters.CodigoADM);
			}
            if (filters.Apelido.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Apelido.Contains(filters.Apelido));
			}
            if (filters.TipoDeParticipanteId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.TipoDeParticipanteId == filters.TipoDeParticipanteId);
			}
            if (filters.NomeCompleto.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.NomeCompleto.Contains(filters.NomeCompleto));
			}
            if (filters.DataDenascimento.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=> _.DataDenascimento >= filters.DataDenascimento.AddHours(-filters.DataDenascimento.Hour).AddMinutes(-filters.DataDenascimento.Minute).AddSeconds(-filters.DataDenascimento.Second) && _.DataDenascimento <= filters.DataDenascimento.AddDays(1).AddHours(-filters.DataDenascimento.Hour).AddMinutes(-filters.DataDenascimento.Minute).AddSeconds(-filters.DataDenascimento.Second));
			}
            if (filters.DataDenascimentoStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.DataDenascimento >= filters.DataDenascimentoStart );
			}
            if (filters.DataDenascimentoEnd.IsSent()) 
			{ 
				filters.DataDenascimentoEnd = filters.DataDenascimentoEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.DataDenascimento  <= filters.DataDenascimentoEnd);
			}

            if (filters.Endereco.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Endereco.Contains(filters.Endereco));
			}
            if (filters.Bairro.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Bairro.Contains(filters.Bairro));
			}
            if (filters.NumeroCasa.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.NumeroCasa == filters.NumeroCasa);
			}
            if (filters.Cep.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Cep.Contains(filters.Cep));
			}
            if (filters.FotoDoParticipanteId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.FotoDoParticipanteId == filters.FotoDoParticipanteId);
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

            if (filters.UserAlterId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserAlterId != null && _.UserAlterId.Value == filters.UserAlterId);
			}


            return queryFilter;
        }

		
    }
}