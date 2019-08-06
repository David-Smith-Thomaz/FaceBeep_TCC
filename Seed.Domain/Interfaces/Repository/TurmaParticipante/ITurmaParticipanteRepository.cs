using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface ITurmaParticipanteRepository : IRepository<TurmaParticipante>
    {
        IQueryable<TurmaParticipante> GetBySimplefilters(TurmaParticipanteFilter filters);

        Task<TurmaParticipante> GetById(TurmaParticipanteFilter turmaparticipante);
		
        Task<IEnumerable<dynamic>> GetDataItem(TurmaParticipanteFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(TurmaParticipanteFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(TurmaParticipanteFilter filters);

        Task<dynamic> GetDataCustom(TurmaParticipanteFilter filters);
    }
}
