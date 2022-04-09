namespace CRM.Domain.Common.Queries.Extensions
{
    using CRM.Domain.Common.Queries.Criteria;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Queries.Abstractions.Builders;
    using global::Domain.Abstracions.Identification;

    public static class FindAllExtensions
    {
        public static Task<List<T>> FindAllAsync<T>(this IAsyncQueryBuilder asyncQueryBuilder, CancellationToken cancellationToken = default)
            where T : class, IHasId, new()
        {
            return asyncQueryBuilder.For<List<T>>().WithAsync(new FindAll(), cancellationToken);
        }
    }
}
