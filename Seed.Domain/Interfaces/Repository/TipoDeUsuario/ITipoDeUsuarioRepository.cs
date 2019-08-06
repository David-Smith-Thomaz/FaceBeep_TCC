using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface ITipoDeUsuarioRepository : IRepository<TipoDeUsuario>
    {
        IQueryable<TipoDeUsuario> GetBySimplefilters(TipoDeUsuarioFilter filters);

        Task<TipoDeUsuario> GetById(TipoDeUsuarioFilter tipodeusuario);
		
        Task<IEnumerable<dynamic>> GetDataItem(TipoDeUsuarioFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(TipoDeUsuarioFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(TipoDeUsuarioFilter filters);

        Task<dynamic> GetDataCustom(TipoDeUsuarioFilter filters);
    }
}
