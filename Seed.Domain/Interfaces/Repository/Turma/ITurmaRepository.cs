using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        IQueryable<Turma> GetBySimplefilters(TurmaFilter filters);

        Task<Turma> GetById(TurmaFilter turma);
		
        Task<IEnumerable<dynamic>> GetDataItem(TurmaFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(TurmaFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(TurmaFilter filters);

        Task<dynamic> GetDataCustom(TurmaFilter filters);
    }
}
