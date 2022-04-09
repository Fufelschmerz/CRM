namespace Queries.Abstractions.Builders
{
    using Queries;

    public interface IAsyncQueryBuilder
    {
        IAsyncQueryFor<TResult> For<TResult>();
    }
}
