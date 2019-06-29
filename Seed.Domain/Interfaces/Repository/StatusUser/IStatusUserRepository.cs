using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface IStatusUserRepository : IRepository<StatusUser>
    {
        IQueryable<StatusUser> GetBySimplefilters(StatusUserFilter filters);

        Task<StatusUser> GetById(StatusUserFilter statususer);
		
        Task<IEnumerable<dynamic>> GetDataItem(StatusUserFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(StatusUserFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(StatusUserFilter filters);

        Task<dynamic> GetDataCustom(StatusUserFilter filters);
    }
}
