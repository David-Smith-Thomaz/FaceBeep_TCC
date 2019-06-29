using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface IRegisterRepository : IRepository<Register>
    {
        IQueryable<Register> GetBySimplefilters(RegisterFilter filters);

        Task<Register> GetById(RegisterFilter register);
		
        Task<IEnumerable<dynamic>> GetDataItem(RegisterFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(RegisterFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(RegisterFilter filters);

        Task<dynamic> GetDataCustom(RegisterFilter filters);
    }
}
