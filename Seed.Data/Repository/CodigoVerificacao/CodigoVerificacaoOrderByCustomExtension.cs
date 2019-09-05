using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class CodigoVerificacaoOrderCustomExtension
    {

        public static IQueryable<CodigoVerificacao> OrderByDomain(this IQueryable<CodigoVerificacao> queryBase, CodigoVerificacaoFilter filters)
        {
            return queryBase.OrderBy(_ => _.CodigoVerificacaoId);
        }

    }
}

