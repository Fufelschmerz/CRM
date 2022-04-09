namespace Linq.Abstractions.AsyncQueryable
{
    using System.Linq;

    public interface IAsyncQueryableFactory
    {
        IAsyncQueryable<T> CreateFrom<T>(IQueryable<T> query);
    }
}
