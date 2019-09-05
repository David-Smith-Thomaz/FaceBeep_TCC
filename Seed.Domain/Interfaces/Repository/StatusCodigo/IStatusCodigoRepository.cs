using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface IStatusCodigoRepository : IRepository<StatusCodigo>
    {
        IQueryable<StatusCodigo> GetBySimplefilters(StatusCodigoFilter filters);

        Task<StatusCodigo> GetById(StatusCodigoFilter statuscodigo);
		
        Task<IEnumerable<dynamic>> GetDataItem(StatusCodigoFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(StatusCodigoFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(StatusCodigoFilter filters);

        Task<dynamic> GetDataCustom(StatusCodigoFilter filters);
    }
}
