using System.Threading;
using System.Threading.Tasks;
using CRM.Domain.Common.Queries.Criteria;
using CRM.Domain.Sources.Objects.Entities;
using Linq.Abstractions.AsyncQueryable;
using Linq.Abstractions.Providers;
using Queries.Linq.Defaults;

namespace CRM.Persistence.ORM.Queries.Entities.Sources
{
    public class FindSourceByNameQuery: LinqAsyncQueryBase<Source, FindByName, Source>
    {
        public FindSourceByNameQuery(ILinqProvider linqProvider, IAsyncQueryableFactory queryableFactory)
            : base(linqProvider, queryableFactory)
        {

        }

        public override Task<Source> ExecuteAsync(FindByName criterion, CancellationToken cancellationToken = default)
        {
            return AsyncQuery.SingleOrDefaultAsync(s=>s.Name == criterion.Name, cancellationToken);
        }
    }
}
