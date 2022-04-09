using System.Threading;
using System.Threading.Tasks;
using CRM.Domain.Common.Queries.Criteria;
using Domain.Abstracions.Identification;
using Linq.Abstractions.AsyncQueryable;
using Linq.Abstractions.Providers;
using Queries.Linq.Defaults;

namespace CRM.Persistence.ORM.Queries.Defaults
{
    public class FindByIdQuery<T> : LinqAsyncQueryBase<T, FindById, T>
        where T : class, IHasId, new()
    {
        public FindByIdQuery(ILinqProvider linqProvider, IAsyncQueryableFactory queryableFactory)
            : base(linqProvider, queryableFactory)
        {

        }

        public override Task<T> ExecuteAsync(FindById criterion, CancellationToken cancellationToken = default)
        {
            return AsyncQuery.SingleOrDefaultAsync(u => u.Id == criterion.Id, cancellationToken);
        }
    }
}
