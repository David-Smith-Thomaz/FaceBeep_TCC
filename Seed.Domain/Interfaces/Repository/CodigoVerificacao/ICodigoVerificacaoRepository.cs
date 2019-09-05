using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface ICodigoVerificacaoRepository : IRepository<CodigoVerificacao>
    {
        IQueryable<CodigoVerificacao> GetBySimplefilters(CodigoVerificacaoFilter filters);

        Task<CodigoVerificacao> GetById(CodigoVerificacaoFilter codigoverificacao);
		
        Task<IEnumerable<dynamic>> GetDataItem(CodigoVerificacaoFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(CodigoVerificacaoFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(CodigoVerificacaoFilter filters);

        Task<dynamic> GetDataCustom(CodigoVerificacaoFilter filters);
    }
}
