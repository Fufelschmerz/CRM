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
    public abstract class LinqAsyncQueryBase<TCriterion, TResult> : IAsyncQuery<TCriterion, TResult>
        where TCriterion : ICriterion
    {
        private readonly ILinqProvider _linqProvider;
        private readonly IAsyncQueryableFactory _queryableFactory;


        protected LinqAsyncQueryBase(ILinqProvider linqProvider, IAsyncQueryableFactory asyncQueryableFactory)
        {
            _linqProvider = linqProvider 
                ?? throw new ArgumentNullException(nameof(linqProvider));
            _queryableFactory = asyncQueryableFactory 
                ?? throw new ArgumentNullException(nameof(asyncQueryableFactory));
        }


        protected virtual IQueryable<THasId> Query<THasId>()
            where THasId : class, IHasId, new()
            => _linqProvider.Query<THasId>();

        protected virtual IAsyncQueryable<THasId> AsyncQuery<THasId>()
            where THasId : class, IHasId, new()
            => ToAsync(Query<THasId>());

        protected IAsyncQueryable<THasId> ToAsync<THasId>(IQueryable<THasId> query)
            where THasId : class, IHasId, new()
            => _queryableFactory.CreateFrom(query);

        public abstract Task<TResult> ExecuteAsync(TCriterion criterion, CancellationToken cancellationToken = default);
    }
}
