using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IQueryable<Usuario> GetBySimplefilters(UsuarioFilter filters);

        Task<Usuario> GetById(UsuarioFilter usuario);
		
        Task<IEnumerable<dynamic>> GetDataItem(UsuarioFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(UsuarioFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(UsuarioFilter filters);

        Task<dynamic> GetDataCustom(UsuarioFilter filters);
    }
}
