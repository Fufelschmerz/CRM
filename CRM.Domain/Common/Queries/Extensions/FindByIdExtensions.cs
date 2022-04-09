namespace CRM.Domain.Common.Queries.Extensions
{
    using CRM.Domain.Common.Queries.Criteria;
    using global::Domain.Abstracions.Identification;
    using global::Queries.Abstractions.Builders;
    using System.Threading;
    using System.Threading.Tasks;

    public static class FindByIdExtensions
    {
        public static Task<T> FindByIdAsync<T>(this IAsyncQueryBuilder asyncQueryBuilder, long id, CancellationToken cancellationToken = default)
            where T: class, IHasId, new()
        {
            return asyncQueryBuilder.For<T>().WithAsync(new FindById(id), cancellationToken);
        }
    }
}
