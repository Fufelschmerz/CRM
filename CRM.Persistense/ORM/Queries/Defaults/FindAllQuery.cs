using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CRM.Domain.Common.Queries.Criteria;
using Domain.Abstracions.Identification;
using Linq.Abstractions.AsyncQueryable;
using Linq.Abstractions.Providers;
using Queries.Linq.Defaults;

namespace CRM.Persistence.ORM.Queries.Defaults
{
    public class FindAllQuery<T> : LinqAsyncQueryBase<T, FindAll, List<T>>
        where T : class, IHasId, new()
    {
        public FindAllQuery(ILinqProvider linqProvider, IAsyncQueryableFactory queryableFactory)
            : base(linqProvider, queryableFactory)
        {

        }

        public override Task<List<T>> ExecuteAsync(FindAll criterion, CancellationToken cancellationToken = default)
        {
            return AsyncQuery.ToListAsync(cancellationToken);
        }
    }
}
