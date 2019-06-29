using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface IStatusRegisterRepository : IRepository<StatusRegister>
    {
        IQueryable<StatusRegister> GetBySimplefilters(StatusRegisterFilter filters);

        Task<StatusRegister> GetById(StatusRegisterFilter statusregister);
		
        Task<IEnumerable<dynamic>> GetDataItem(StatusRegisterFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(StatusRegisterFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(StatusRegisterFilter filters);

        Task<dynamic> GetDataCustom(StatusRegisterFilter filters);
    }
}
