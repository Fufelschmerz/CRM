﻿namespace Queries.Abstractions.Queries
{
    using Criterions;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAsyncQuery<in TCriterion, TResult> where TCriterion : ICriterion
    {
        Task<TResult> ExecuteAsync(TCriterion criterion, CancellationToken cancellationToken = default);
    }
}
