using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface ITypeUserRepository : IRepository<TypeUser>
    {
        IQueryable<TypeUser> GetBySimplefilters(TypeUserFilter filters);

        Task<TypeUser> GetById(TypeUserFilter typeuser);
		
        Task<IEnumerable<dynamic>> GetDataItem(TypeUserFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(TypeUserFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(TypeUserFilter filters);

        Task<dynamic> GetDataCustom(TypeUserFilter filters);
    }
}
