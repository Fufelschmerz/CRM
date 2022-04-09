namespace Repositories.Abstractions
{
    using Domain.Abstracions.Identification;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAsyncRepository<T> where T : class, IHasId, new()
    {
        Task AddAsync(T objWithId, CancellationToken cancellationToken = default);

        Task DeleteAsync(T objWithId, CancellationToken cancellationToken = default);
    }
}
