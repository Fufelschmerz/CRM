namespace CRM.Domain.Sources.Services
{
    using Commands.Absctractions.Builders;
    using CRM.Domain.Common.Commands.Extensions;
    using Exceptions;
    using Objects.Entities;
    using Queries.Abstractions.Builders;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using CRM.Domain.Common.Queries.Extensions;
    using Abstractions;

    public class SourceService : ISourceService
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        private readonly IAsyncCommandBuilder _commandBuilder;

        public SourceService(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder ??
                throw new ArgumentException(nameof(queryBuilder));

            _commandBuilder = commandBuilder ??
                throw new ArgumentException(nameof(commandBuilder));
        }

        public async Task<Source> CreateSourceAsync(string name, CancellationToken cancellationToken= default)
        {
            await CheckSourceByNameAsync(name, cancellationToken);

            var source = new Source(name);

            await _commandBuilder.CreateAsync(source, cancellationToken);

            return source;
        }

        public async Task DeleteSourceAsync(Source source, CancellationToken cancellationToken = default)
        {
            await _commandBuilder.DeleteAsync(source, cancellationToken);
        }

        public async Task EditSourceAsync(Source source, string name, CancellationToken cancellationToken = default)
        {
            await CheckSourceByNameAsync(name, cancellationToken);
            
            source.CreateOrEditSource(name);
        }

        private async Task CheckSourceByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var source = await _queryBuilder.FindByNameAsync<Source>(name, cancellationToken);

            if(source != null)
                throw new SourceAlreadyExistsException();
        }
    }
}
