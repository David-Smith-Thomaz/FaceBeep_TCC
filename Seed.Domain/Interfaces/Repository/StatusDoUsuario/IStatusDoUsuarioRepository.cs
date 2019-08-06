using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface IStatusDoUsuarioRepository : IRepository<StatusDoUsuario>
    {
        IQueryable<StatusDoUsuario> GetBySimplefilters(StatusDoUsuarioFilter filters);

        Task<StatusDoUsuario> GetById(StatusDoUsuarioFilter statusdousuario);
		
        Task<IEnumerable<dynamic>> GetDataItem(StatusDoUsuarioFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(StatusDoUsuarioFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(StatusDoUsuarioFilter filters);

        Task<dynamic> GetDataCustom(StatusDoUsuarioFilter filters);
    }
}
