namespace CRM.Persistence.ORM.Queries.Entities.States
{
    using System.Threading;
    using System.Threading.Tasks;
    using CRM.Domain.States.Criteria;
    using CRM.Domain.States.Objects.Entities;
    using Linq.Abstractions.AsyncQueryable;
    using Linq.Abstractions.Providers;
    using global::Queries.Linq.Defaults;

    public class FindStateByNameAndTypeQuery : LinqAsyncQueryBase<State, FindStateByNameAndType, State>
    {
        public FindStateByNameAndTypeQuery(ILinqProvider linqProvider, IAsyncQueryableFactory queryableFactory)
            : base(linqProvider, queryableFactory)
        {

        }

        public override Task<State> ExecuteAsync(FindStateByNameAndType criterion, CancellationToken cancellationToken = default)
        {
            return AsyncQuery.SingleOrDefaultAsync(x => x.Name == criterion.Name && x.Status == criterion.Status,
                cancellationToken);
        }
    }
}
