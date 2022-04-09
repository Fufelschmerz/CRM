namespace CRM.Domain.Sources.Services.Abstractions
{
    using Objects.Entities;
    using global::Domain.Abstracions.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ISourceService : IDomainService
    {
        Task<Source> CreateSourceAsync(string name, CancellationToken cancellationToken = default);

        Task EditSourceAsync(Source source, string name, CancellationToken cancellationToken = default);

        Task DeleteSourceAsync(Source source, CancellationToken cancellationToken = default);
    }
}
