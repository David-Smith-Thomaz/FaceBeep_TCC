using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface IParticipantRepository : IRepository<Participant>
    {
        IQueryable<Participant> GetBySimplefilters(ParticipantFilter filters);

        Task<Participant> GetById(ParticipantFilter participant);
		
        Task<IEnumerable<dynamic>> GetDataItem(ParticipantFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(ParticipantFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(ParticipantFilter filters);

        Task<dynamic> GetDataCustom(ParticipantFilter filters);
    }
}
