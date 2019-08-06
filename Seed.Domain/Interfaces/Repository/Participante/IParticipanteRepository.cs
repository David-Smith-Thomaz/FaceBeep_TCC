using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface IParticipanteRepository : IRepository<Participante>
    {
        IQueryable<Participante> GetBySimplefilters(ParticipanteFilter filters);

        Task<Participante> GetById(ParticipanteFilter participante);
		
        Task<IEnumerable<dynamic>> GetDataItem(ParticipanteFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(ParticipanteFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(ParticipanteFilter filters);

        Task<dynamic> GetDataCustom(ParticipanteFilter filters);
    }
}
