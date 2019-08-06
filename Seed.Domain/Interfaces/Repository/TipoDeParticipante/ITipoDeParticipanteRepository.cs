using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface ITipoDeParticipanteRepository : IRepository<TipoDeParticipante>
    {
        IQueryable<TipoDeParticipante> GetBySimplefilters(TipoDeParticipanteFilter filters);

        Task<TipoDeParticipante> GetById(TipoDeParticipanteFilter tipodeparticipante);
		
        Task<IEnumerable<dynamic>> GetDataItem(TipoDeParticipanteFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(TipoDeParticipanteFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(TipoDeParticipanteFilter filters);

        Task<dynamic> GetDataCustom(TipoDeParticipanteFilter filters);
    }
}
