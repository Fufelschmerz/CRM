using System;

namespace CRM.Application.Controllers.Sources.Actions.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using CRM.Application.Infrastructure.Exceptions.Sources;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Sources.Objects.Entities;
    using CRM.Domain.Sources.Services.Abstractions;
    using Queries.Abstractions.Builders;

    public class DeleteSourceRequestHandler : IAsyncRequestHandler<DeleteSourceRequest>
    {
        private readonly ISourceService _sourceService;

        private readonly IAsyncQueryBuilder _queryBuilder;

        public DeleteSourceRequestHandler(ISourceService sourceService, IAsyncQueryBuilder queryBuilder)
        {
            _sourceService = sourceService ??
                             throw new ArgumentNullException(nameof(sourceService));

            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(DeleteSourceRequest request, CancellationToken cancellationToken = default)
        {
            var source = await _queryBuilder.FindByIdAsync<Source>(request.Id, cancellationToken)
                ?? throw new SourceNotFoundException();

            await _sourceService.DeleteSourceAsync(source, cancellationToken);
        }
    }
}
