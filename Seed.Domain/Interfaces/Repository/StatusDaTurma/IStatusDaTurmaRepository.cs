using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface IStatusDaTurmaRepository : IRepository<StatusDaTurma>
    {
        IQueryable<StatusDaTurma> GetBySimplefilters(StatusDaTurmaFilter filters);

        Task<StatusDaTurma> GetById(StatusDaTurmaFilter statusdaturma);
		
        Task<IEnumerable<dynamic>> GetDataItem(StatusDaTurmaFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(StatusDaTurmaFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(StatusDaTurmaFilter filters);

        Task<dynamic> GetDataCustom(StatusDaTurmaFilter filters);
    }
}
