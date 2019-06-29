using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface IGroupParticipantRepository : IRepository<GroupParticipant>
    {
        IQueryable<GroupParticipant> GetBySimplefilters(GroupParticipantFilter filters);

        Task<GroupParticipant> GetById(GroupParticipantFilter groupparticipant);
		
        Task<IEnumerable<dynamic>> GetDataItem(GroupParticipantFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(GroupParticipantFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(GroupParticipantFilter filters);

        Task<dynamic> GetDataCustom(GroupParticipantFilter filters);
    }
}
