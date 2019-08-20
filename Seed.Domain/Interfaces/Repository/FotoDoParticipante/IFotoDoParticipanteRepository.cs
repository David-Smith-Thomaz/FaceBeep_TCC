using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface IFotoDoParticipanteRepository : IRepository<FotoDoParticipante>
    {
        IQueryable<FotoDoParticipante> GetBySimplefilters(FotoDoParticipanteFilter filters);

        Task<FotoDoParticipante> GetById(FotoDoParticipanteFilter fotodoparticipante);
		
        Task<IEnumerable<dynamic>> GetDataItem(FotoDoParticipanteFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(FotoDoParticipanteFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(FotoDoParticipanteFilter filters);

        Task<dynamic> GetDataCustom(FotoDoParticipanteFilter filters);
    }
}
