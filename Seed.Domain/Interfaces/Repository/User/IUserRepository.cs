using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> GetBySimplefilters(UserFilter filters);

        Task<User> GetById(UserFilter user);
		
        Task<IEnumerable<dynamic>> GetDataItem(UserFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(UserFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(UserFilter filters);

        Task<dynamic> GetDataCustom(UserFilter filters);
    }
}
