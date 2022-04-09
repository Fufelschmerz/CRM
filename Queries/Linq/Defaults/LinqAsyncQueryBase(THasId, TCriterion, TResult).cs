using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Abstracions.Identification;
using Linq.Abstractions.AsyncQueryable;
using Linq.Abstractions.Providers;
using Queries.Abstractions.Criterions;
using Queries.Abstractions.Queries;

namespace Queries.Linq.Defaults
{
    public abstract class LinqAsyncQueryBase<THasId, TCriterion, TResult> : IAsyncQuery<TCriterion, TResult>
        where THasId : class, IHasId, new()
        where TCriterion : ICriterion
    {
        private readonly ILinqProvider _linqProvider;
        private readonly IAsyncQueryableFactory _queryableFactory;

        protected LinqAsyncQueryBase(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory queryableFactory)
        {
            _linqProvider = linqProvider 
                ?? throw new ArgumentNullException(nameof(linqProvider));
            _queryableFactory = queryableFactory 
                ?? throw new ArgumentNullException(nameof(queryableFactory));
        }


        protected virtual IQueryable<THasId> Query => _linqProvider.Query<THasId>();

        protected virtual IAsyncQueryable<THasId> AsyncQuery => ToAsync(Query);

        protected IAsyncQueryable<TOtherHasId> ToAsync<TOtherHasId>(IQueryable<TOtherHasId> query)
            where TOtherHasId : THasId
            => _queryableFactory.CreateFrom(query);

        public abstract Task<TResult> ExecuteAsync(TCriterion criterion, CancellationToken cancellationToken = default);
    }
}
