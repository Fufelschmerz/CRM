namespace Linq.Abstractions.Providers
{
    using Domain.Abstracions.Identification;
    using System.Linq;

    public interface ILinqProvider
    {
        IQueryable<T> Query<T>()
            where T : class, IHasId, new();
    }
}
