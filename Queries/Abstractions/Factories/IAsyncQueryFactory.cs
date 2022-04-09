namespace Queries.Abstractions.Factories
{
    using Criterions;
    using Queries;

    public interface IAsyncQueryFactory
    {
        IAsyncQuery<TCriterion, TResult> Create<TCriterion, TResult>() where TCriterion : ICriterion;
    }
}
