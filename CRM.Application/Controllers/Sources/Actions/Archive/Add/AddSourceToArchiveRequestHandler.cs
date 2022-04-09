namespace CRM.Application.Controllers.Sources.Actions.Archive.Add
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using CRM.Application.Infrastructure.Exceptions.Sources;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Sources.Objects.Entities;
    using Queries.Abstractions.Builders;

    public class AddSourceToArchiveRequestHandler : IAsyncRequestHandler<AddSourceToArchiveRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        public AddSourceToArchiveRequestHandler(IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ??
                throw new ArgumentException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(AddSourceToArchiveRequest request, CancellationToken cancellationToken = default)
        {
            var source = await _queryBuilder.FindByIdAsync<Source>(request.Id, cancellationToken) ??
                throw new SourceNotFoundException();

            source.AddSourceToArchive();
        }
    }
}
