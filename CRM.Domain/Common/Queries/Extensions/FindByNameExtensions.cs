namespace CRM.Domain.Common.Queries.Extensions
{
    using Criteria;
    using global::Domain.Abstracions.Identification;
    using global::Queries.Abstractions.Builders;
    using System.Threading;
    using System.Threading.Tasks;

    public static class FindByNameExtensions
    {
        public static Task<T> FindByNameAsync<T>(this IAsyncQueryBuilder asyncQueryBuilder, string name, CancellationToken cancellationToken = default)
            where T : class, IHasId, new()
        {
            return asyncQueryBuilder.For<T>().WithAsync(new FindByName(name), cancellationToken);
        }
    }
}
